using App.IdentityServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stocky;
using Stocky.Data.Entities;
using Stocky.Data.Models;
using Stocky.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Stocky.Core.Extensions;
using System.IO;

namespace StockApp.Controllers
{
    [Authorize]
    [Route("api/Account")]
    public class AccountController : ControllerBase
    {
        public static string supAdminRole = Constants.SuperAdminRole;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IPermissionService _permissions;
        private readonly IAccounService _accounService;

        #region constructor
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IMapper mapper,
            AppDbContext context,
            IPermissionService permission,
            IHttpContextAccessor accessor,
            IAccounService accounService,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _mapper = mapper;
            _context = context;
            _permissions = permission;
            _accounService = accounService;
        }
        #endregion

        #region Create new user 
        /// <summary>
        /// 1- create user
        /// 2- Create Default Permissions (if owner).
        /// 3- Crete Default Location (if owner).
        /// 4- Assign selected roles, or default roles (if owner).
        /// </summary>
        /// <param name="user">
        /// [FromBody] UserCreateModel user
        /// </param>
        /// <returns></returns>
        /// 

        // api/account/createuser
        [Authorize(Policy = "create-users")]
        [HttpPost, Route("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateModel user)
        {
            var response = BadRequest(new Result { Success = false });
            var ownerRole = "owner-" + SharedKey.Substring(0, 12).Trim().ToLowerInvariant();

            // if state is not valid then retrurn 
            if (ModelState.IsValid == false)
            {
                return BadRequest(new
                {
                    Success = false,
                    Errors = new SerializableError(ModelState)
                });
            };

            // username is optional. 
            if (string.IsNullOrWhiteSpace(user.UserName)) user.UserName = user.Email;

            #region create user
            var newUser = _mapper.Map<ApplicationUser>(user);

            // if new user is owner created by superadmin then create new 'Key', otherwise share loggedin user key 
            if (User.IsInRole(supAdminRole))
            {
                newUser.SharedKey = Guid.NewGuid().ToString();
                newUser.IsOwner = true;
                user.IsOwner = true;
            }
            else
            {
                newUser.SharedKey = SharedKey;
                user.IsOwner = false;
                newUser.IsOwner = false;
            }

            newUser.CreatedBy = UserId;
            newUser.CreatedDate = DateTime.Now;
            newUser.IsActive = true;

            // create new user, if not succeeded then return
            var idResult = await _userManager.CreateAsync(newUser, user.Password);
            if (idResult.Succeeded == false)
            {
                response = BadRequest(new Result()
                {
                    Success = false,
                    Errors = idResult.Errors.Select(e => e.Description).ToArray(),
                    Data = null
                });

                return response;
            }

            newUser = await _userManager.FindByNameAsync(newUser.UserName);
            #endregion

            #region Assign roles to new user
            if (User.IsInRole(supAdminRole) == false)
            {
                try
                {
                    var roles = user.Roles.Where(x => x.Trim().ToLowerInvariant() != ownerRole).Distinct();

                    foreach (var roleName in roles)
                    {
                        // ensure all roles exist. if not then throw exception
                        if (await _roleManager.RoleExistsAsync(roleName) == false)
                        {
                            throw new Exception("found invalid roles");
                        }
                    }


                    // Assign roles to new user
                    idResult = await _userManager.AddToRolesAsync(newUser, roles);
                }
                catch (Exception ex)
                {
                    await _accounService.DeleteUserAsync(newUser);
                    response = BadRequest(new Result()
                    {
                        Success = false,
                        Errors = idResult.Errors.Select(e => e.Description).ToArray(),
                        Data = null
                    });

                    return response;
                }

                if (idResult.Succeeded == false)
                {
                    await _accounService.DeleteUserAsync(newUser);
                    response = BadRequest(new Result()
                    {
                        Success = false,
                        Errors = idResult.Errors.Select(e => e.Description).ToArray(),
                        Data = null
                    });

                    return response;
                }
            }
            #endregion

            #region create default setting
            try
            {
                // allow only super admin to create owner
                if (User.IsInRole(supAdminRole))
                {
                    // if owner, then create default setting
                    if (user.IsOwner)
                    {
                        var isSuccess = AddLocation(newUser);

                        if (isSuccess) isSuccess = await _accounService.CreateDefaultPermissions(newUser, UserId);
                        if (isSuccess == false) throw new Exception("something went wrong");
                    }
                }
            }
            catch (Exception ex)
            {
                await _accounService.DeleteUserAsync(newUser);
                response = BadRequest(
                new Result
                {
                    Success = false,
                    Errors = idResult.Errors.Select(e => e.Description).ToArray(),
                    Data = null
                });

                return response;
            }

            #endregion


            var userRoles = new List<string>();
            var roleNames = await _userManager.GetRolesAsync(newUser);
            foreach (var name in roleNames.Distinct())
            {
                var role = _roleManager.Roles.Where(x => x.Name == name).FirstOrDefault();

                if (role != null) userRoles.Add(role.DisplayName);
            }

            return Ok(
           new Result
            {
                Success = true,
                Data = new
                {
                    User = newUser,
                    Roles = userRoles
                }
            });
        }

        #endregion

        #region Delete User
        // api/account/deleteuser/id
        [HttpDelete, Route("deleteuser/{id}")]
        [Authorize(Policy = "delete-users")]
        public async Task<IActionResult> DeleteUserByIdAsync(string id)
        {
            var result = new Result();
            try
            {
                // Todo:  - add contraints, who can delete...
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return NotFound(result);

                if (IsPermitted(user.SharedKey) == false) return Forbid();

                var idResult = await _accounService.DeleteUserAsync(user);
                if (idResult.Succeeded == false)
                {
                    result.Errors = idResult.Errors.Select(e => e.Description).ToArray();
                    return BadRequest(result);
                }

                result.Success = idResult.Succeeded;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                return BadRequest(result);
            }
        }
        #endregion

        #region Create Role
        //api/account/createrole
        [HttpPost, Route("createrole")]
        [Authorize(Policy = "create-roles")]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateModel model)
        {
            var result = new Result();
            var role = new ApplicationRole();
            IdentityResult IdResult = null;

            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(new
                    {
                        Errors = new SerializableError(ModelState),
                        Success = false
                    });
                }

                var roleToCreate = model.RoleName + "-" + SharedKey.Substring(0, 12);
                if (model.Claims == null) model.Claims = new string[] { };
                var invalidClaims = model.Claims.Where(c => _permissions.GetAllPermissions().Where(x => x.Value.ToLowerInvariant() == c.ToLowerInvariant()) == null).ToArray();

                if (invalidClaims.Any())
                {
                    result = new Result()
                    {
                        Success = false,
                        Errors = new[] { "The following claim types are invalid: " + string.Join(", ", invalidClaims) },
                        Data = null
                    };

                    return BadRequest(result);
                }

                if (await _roleManager.RoleExistsAsync(roleToCreate) == false)
                {
                    role = new ApplicationRole
                    {
                        Name = roleToCreate.Trim().ToLowerInvariant(),
                        DisplayName = model.RoleName,
                        CreatedBy = UserId,
                        SharedKey = SharedKey,
                        IsActive = model.IsActive,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                    };

                    IdResult = await _roleManager.CreateAsync(role);
                    if (IdResult.Succeeded == false)
                    {
                        result = new Result()
                        {
                            Success = false,
                            Errors = IdResult.Errors.Select(e => e.Description).ToArray(),
                            Data = null
                        };

                        return BadRequest(result);
                    }

                    role = await _roleManager.FindByNameAsync(role.Name);
                    foreach (string claim in model.Claims.Distinct())
                    {
                        IdResult = await this._roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, claim));

                        if (IdResult.Succeeded == false)
                        {
                            await _accounService.DeleteRoleAsync(role);

                            result = new Result()
                            {
                                Success = false,
                                Errors = IdResult.Errors.Select(e => e.Description).ToArray(),
                            };

                            return BadRequest(result);
                        }
                    }
                }
                else
                {
                    result.AddError("Role already exists");

                    return BadRequest(result);
                }


                result = new Result
                {
                    Success = true,
                    Data = new
                    {
                        role.Id,
                        Role = model.RoleName,
                        model.Claims
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                await _accounService.DeleteRoleAsync(role);

                result = new Result()
                {
                    Success = false,
                    Errors = IdResult.Errors.Select(e => e.Description).ToArray(),
                };

                return BadRequest(result);
            }
        }
        #endregion

        #region Update Role 
        //api/account/updaterole
        [HttpPut("updaterole/{id}")]
        [Authorize(Policy = "update-roles")]
        public async Task<IActionResult> UpdateRoleAsync([FromBody, FromQuery] RoleUpdateModel model)
        {
            var result = new Result();
            IdentityResult IdResult = null;
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(new
                    {
                        Errors = new SerializableError(ModelState),
                        Success = false
                    });
                }

                var role = _roleManager.Roles.FirstOrDefault(r => r.Id == model.Id);
                if (role == null) return NotFound(result);
                if (IsPermitted(role.SharedKey) == false) return Forbid();

                if (model.Claims != null)
                {
                    var permissions = _permissions.GetAllPermissions();

                    string[] invalidClaims = model.Claims.Where(c => permissions.Where(x => x.Value == c) == null).ToArray();
                    if (invalidClaims.Any())
                    {
                        result = new Result()
                        {
                            Success = false,
                            Errors = new[] { "The following claim types are invalid: " + string.Join(", ", invalidClaims) },
                            Data = null
                        };

                        return BadRequest(result);
                    }
                }

                role.DisplayName = model.DisplayName ?? role.DisplayName;
                role.IsActive = model.IsActive;
                IdResult = await _roleManager.UpdateAsync(role);

                if (IdResult.Succeeded == false)
                {
                    result = new Result()
                    {
                        Success = false,
                        Errors = IdResult.Errors.Select(e => e.Description).ToArray()
                    };

                    return BadRequest(result);
                }

                if (model.Claims != null)
                {
                    var roleClaims = (await _roleManager.GetClaimsAsync(role)).Where(c => c.Type == CustomClaimTypes.Permission);
                    var roleClaimValues = roleClaims.Select(c => c.Value).ToArray();

                    var claimsToRemove = roleClaimValues.Except(model.Claims).ToArray();
                    var claimsToAdd = model.Claims.Except(roleClaimValues).Distinct().ToArray();

                    if (claimsToRemove.Any())
                    {
                        foreach (string claim in claimsToRemove)
                        {
                            var claimToRemove = roleClaims.Where(c => c.Value == claim).FirstOrDefault();
                            IdResult = await _roleManager.RemoveClaimAsync(role, claimToRemove);
                            if (IdResult.Succeeded == false)
                            {
                                result = new Result()
                                {
                                    Success = false,
                                    Errors = IdResult.Errors.Select(e => e.Description).ToArray()
                                };

                                return BadRequest(result);
                            }
                        }
                    }

                    if (claimsToAdd.Any())
                    {
                        foreach (string claim in claimsToAdd)
                        {
                            IdResult = await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, claim));
                            if (IdResult.Succeeded == false)
                            {
                                result = new Result()
                                {
                                    Success = false,
                                    Errors = IdResult.Errors.Select(e => e.Description).ToArray()
                                };

                                return BadRequest(result);
                            }
                        }
                    }
                }

                result.Success = true;
                result.Data = new
                {
                    Role = role,
                    model.Claims
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                return BadRequest(result);
            }
        }
        #endregion

        #region Delete Role
        //api/account/deleterole/[id/name]
        [HttpDelete("deleterole/{role}")]
        [Authorize(Policy = "delete-roles")]
        public async Task<IActionResult> DeleteRoleAsync(string role)
        {
            var result = new Result();
            try
            {
                // _roleManager.FindByIdAsync(id);
                var roleDb = await _roleManager.FindByNameAsync(role);
                if (roleDb == null) roleDb = await _roleManager.FindByIdAsync(role);
                if (roleDb == null) return NotFound();
                if (IsPermitted(roleDb.SharedKey) == false) return Forbid();

                var idResult = await _accounService.DeleteRoleAsync(roleDb);
                if (idResult.Succeeded == false)
                {
                    result.Success = false;
                    result.Errors = idResult.Errors.Select(e => e.Description).ToArray();

                    return BadRequest(result);
                };

                result.Data = role;
                result.Success = idResult.Succeeded;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                return BadRequest(result);
            }
        }
        #endregion

        #region Get User GetUsers
        // api/account/getusers
        // Todo: - filter, sort, search
        [HttpGet, Route("getusers")]
        [Authorize(Policy = "view-users")]
        public async Task<IActionResult> GetUsersWithRolesAsync([FromQuery, FromRoute] UserResourceParameters parameters)
        {
            var result = new Result();
            try
            {
                var usersQry = _userManager.Users.Where(u => u.IsActive && u.IsDeleted == false && u.Id != UserId);
                if (User.IsInRole(supAdminRole) == false) usersQry = usersQry.Where(u => u.SharedKey == SharedKey);

                var queryResult = _mapper.Map<IEnumerable<UserListModel>>(usersQry).AsQueryable();
                queryResult = _accounService.FilterUsers(queryResult, parameters);
                var data = queryResult.GetPaged(parameters.PageNo, parameters.PageSize);

                result.Success = true;
                result.Data = data;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return BadRequest(result);
        }

        // api/account/getusers/id
        [HttpGet("getusers/{searchParam}")]
        [Authorize(Policy = "view-users")]
        public async Task<IActionResult> GetUserInfoAsync([FromRoute] string searchParam)
        {
            var result = new Result { Data = searchParam };
            try
            {
                var user = await _userManager.FindByIdAsync(searchParam);
                if (user == null) user = await _userManager.FindByNameAsync(searchParam);
                if (user == null) user = await _userManager.FindByEmailAsync(searchParam);
                if (user == null) return NotFound(result);
                if (IsPermitted(user.SharedKey) == false) return Forbid();

                var userRoles = await _accounService.GetUserRolesAsync(user);
                var userPermissions = await _accounService.GetUserPermissionsAsync(user);

                var userInfo = _mapper.Map<UserInfoModel>(user);
                userInfo.Roles = userRoles;
                userInfo.Claims = userPermissions;

                result = new Result
                {
                    Success = true,
                    Data = userInfo,
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return BadRequest(result);
        }

        #endregion

        #region Update user
        // api/account/updateuser 
        [HttpPut("updateuser/{id}")]
        [Authorize(Policy = "update-users")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateModel updateModel)
        {
            var result = new Result();
            try
            {
                // var user = await _userManager.FindByIdAsync(updateModel.Id);
                var user = _userManager.Users.FirstOrDefault(x => x.Id == updateModel.Id);
                if (user == null) return NotFound(result);
                if (IsPermitted(user.SharedKey) == false) return Forbid();

                if (ModelState.IsValid == false)
                {
                    return BadRequest(new
                    {
                        Errors = new SerializableError(ModelState),
                        Success = false
                    });
                }

                user.UserName = updateModel.UserName ?? updateModel.Email; // if null default to email
                user.Email = updateModel.Email ?? updateModel.Email;
                user.FirstName = updateModel.FirstName;
                user.LastName = updateModel.LastName;
                user.Designation = updateModel.Designation;
                user.PhoneNumber = updateModel.PhoneNumber;
                user.IsActive = updateModel.IsActive;

                result = await _accounService.UpdateUserAsync(user, updateModel?.Roles);
                if (result.Success == false) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return BadRequest(result);
        }
        #endregion

        #region update profile
        [HttpPut("updateprofile/{id}")]
        public async Task<IActionResult> UpdateProfile([FromBody, FromQuery] UserUpdateModel updateModel)
        {
            var user = await GetUser();
            var idResult = new IdentityResult();
            try
            {
                if (string.IsNullOrWhiteSpace(updateModel.Email)) return BadRequest("Email is required");

                user.UserName = updateModel.UserName ?? user.Email; // if null default to email
                user.Email = updateModel.Email;
                user.FirstName = updateModel.FirstName;
                user.LastName = updateModel.LastName;
                user.Designation = updateModel.Designation;
                user.PhoneNumber = updateModel.PhoneNumber;

                idResult = await _userManager.UpdateAsync(user);
                if (idResult.Succeeded) return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }

            return BadRequest("Something went wrong");
        }

        [HttpPut("updateavatar")]
        public async Task<IActionResult> UpdateAvatarAsync()
        {
            try
            {
                // TODO: Update upload
                var avatar = Request.Form.Files[0];
                var idResult = new IdentityResult();

                if (avatar != null)
                {
                    if (avatar.Length > 0)
                    {
                        var user = await GetUser();
                        var img = new Image
                        {
                            ContentType = avatar.ContentType,
                            CreatedBy = user.Id,
                            CreatedDate = DateTime.Now,
                            Name = avatar.FileName,
                            IsActive = true,
                            SharedKey = SharedKey,
                            UserId = user.Id
                        };

                        // Save file in database
                        using (var fileStream = avatar.OpenReadStream())
                        using (var memoryStream = new MemoryStream())
                        {
                            fileStream.CopyTo(memoryStream);
                            img.Data = memoryStream.ToArray();
                        }

                        _context.Images.Add(img);
                        var Succeeded = await _context.SaveChangesAsync() > 0;

                        // Save file on server
                        var fileDir = $"wwwroot/media/{user.SharedKey}/avatars";
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileDir);
                        if (Directory.Exists(filePath) == false) Directory.CreateDirectory(filePath);

                        var ext = Path.GetExtension(avatar.FileName);
                        var avatarPath = $@"{filePath}/{img.Id}{ext}";
                        img.Data.SaveOnDisk(avatarPath);
                        //System.IO.File.WriteAllBytes(avatarPath, img.Data);

                        // update url in user & Image
                        user.AvatarURL = $"{fileDir}/{img.Id}{ext}";
                        img.ImageURL = user.AvatarURL;

                        idResult = await _userManager.UpdateAsync(user);

                        var avatarURL = new
                        {
                            avatarURL = user.AvatarURL
                        };
                        if (idResult.Succeeded) return Ok(avatarURL);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return BadRequest();
        }

        [HttpPut("updateavatar/{id}")]
        public async Task<IActionResult> UpdateSelectAvatarAsync([FromBody] Image image)
        {
            try 
            {
                if (image == null) return BadRequest();

                var images = _context.Images.Where(x => x.UserId == image.UserId).Include(x => x.User); 
                await images.ForEachAsync(x => x.IsActive = false);

                var img = await images.FirstOrDefaultAsync(x => x.Id == image.Id && x.UserId == image.UserId);
                if (img == null) return NotFound();

                img.User.AvatarURL = img.ImageURL;
                img.IsActive = true;

                await _context.SaveChangesAsync();
                return Ok(img);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Get loggedIn user info
        [HttpGet, Route("getuser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await GetUser();
            if (user == null) return BadRequest();
            var userInfoModel = _mapper.Map<UserInfoModel>(user);
            userInfoModel.Images = _context.Images.Where(x => x.UserId == user.Id)
                .Select(x => new Image {
                    Id = x.Id,
                    UserId = x.UserId,
                    Name = x.Name,
                    ImageURL = x.ImageURL,
                    IsActive = x.IsActive
                });
            //if (user.Avatar != null)
            //{
            //    var imageString = Convert.ToBase64String(user.Avatar);
            //    userInfoModel.AvatarURL = $"{user?.AvatarMeta}{imageString}";
            //}

            return Ok(userInfoModel);
        }
        #endregion


        #region Get Roles
        // api/account/getroles/[name/id]
        [HttpGet, Route("getroles/{role}")]
        [Authorize(Policy = "view-roles")]
        public async Task<IActionResult> GetRolesync([FromRoute] string role)
        {
            var result = new Result();

            var roleNDb = await _roleManager.FindByNameAsync(role);
            if (roleNDb == null) roleNDb = await _roleManager.FindByIdAsync(role);

            if (roleNDb == null)
            {
                result.AddError("Role not found.");
                return NotFound(result);
            }

            if (IsPermitted(roleNDb.SharedKey) == false) return Forbid();

            var claims = await _accounService.GetRolePermissionsAsync(roleNDb);
            var users = await _accounService.GetRoleUsersAsync(roleNDb.Name);

            result.Success = true;
            result.Data = new
            {
                roleNDb.Name,
                roleNDb.DisplayName,
                roleNDb.Id,
                Claims = claims,
                Users = users
            };

            return Ok(result);
        }

        // api/account/getroles 
        [HttpGet, Route("getroles")]
        [Authorize(Policy = "view-roles")]
        public async Task<IActionResult> GetRoles([FromQuery] RoleResourceParameters parameters)
        {
            var result = new Result();

            try
            {
                var rolesQry = _roleManager.Roles.Where(x => x.IsActive && !x.IsDeleted);
                if (User.IsInRole(supAdminRole) == false) rolesQry = rolesQry.Where(u => u.SharedKey == SharedKey);

                var queryResult = _mapper.Map<IEnumerable<RoleListModel>>(rolesQry).AsQueryable();
                // todo: - apply filter, sort & serach query
                queryResult = _accounService.FilterRoles(queryResult, parameters);

                var data = queryResult.GetPaged(parameters.PageNo, parameters.PageSize);

                //var ownerRole = _roleManager.Roles.FirstOrDefault(x => x.SharedKey == user.SharedKey+"_opac" && x.IsActive && !x.IsDeleted); 

                result.Success = true;
                result.Data = data;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return BadRequest(result);
        }

        // get all roles without paggination.
        // api/account/getallroles 
        [HttpGet, Route("getallroles")]
        [Authorize(Policy = "view-roles")]
        public IActionResult GetAllRoles([FromQuery] RoleResourceParameters parameters)
        {
            var result = new Result();

            try
            {
                var rolesQry = _roleManager.Roles.Where(x => x.IsActive && !x.IsDeleted);
                rolesQry = rolesQry.Where(u => u.SharedKey == SharedKey);

                var queryResult = _mapper.Map<IEnumerable<RoleListModel>>(rolesQry).ToArray();

                result.Success = true;
                result.Data = queryResult;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return BadRequest(result);
        }

        #endregion


        #region get permissions
        // api/account/getpermissions
        [HttpGet, Route("getpermissions")]
        [Authorize(Policy = "view-roles")]
        public IActionResult GetPermissions()
        {
            var result = new Result();
            try
            {
                var permissions = _permissions.GetAllPermissions();
                result.Success = true;

                var data = _mapper.Map<IEnumerable<PermissionListModel>>(permissions).GroupBy(per => per.GroupName);

                var permissionGroups = new List<object>();
                foreach (var item in data)
                {
                    permissionGroups.Add(new
                    {
                        Group = item.Key,
                        Permissions = item
                    });
                }

                result.Data = permissionGroups;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }

            return BadRequest();
        }
        #endregion



        public async Task<Result> ResetPasswordAsync(ApplicationUser user, string newPassword)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (!result.Succeeded)
                return new Result() { Success = false, Errors = result.Errors.Select(e => e.Description).ToArray() };

            return new Result() { Success = true };
        }

        public async Task<Result> UpdatePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
                return new Result() { Success = false, Errors = result.Errors.Select(e => e.Description).ToArray() }; // Tuple.Create(false, result.Errors.Select(e => e.Description).ToArray());

            return new Result() { Success = true }; //Tuple.Create(true, new string[] { });
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                if (!_userManager.SupportsUserLockout) await _userManager.AccessFailedAsync(user);

                return false;
            }

            return true;
        }

        private bool AddLocation(ApplicationUser user)
        {
            try
            {
                if (user == null) return false;

                Location location = new Location
                {
                    Name = "Default Location",
                    CreatedBy = user.Id,
                    SharedKey = user.SharedKey,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                };

                _context.Locations.Add(location);
                return _context.SaveChanges() > 0;
            }

            catch (Exception ex) { }

            return false;
        }

        private IEnumerable<string> GetModelErrors()
        {
            var errors = new List<string>();
            foreach (var modelStateVal in ModelState.Values)
            {
                foreach (var error in modelStateVal.Errors)
                {
                    errors.Add(error.ErrorMessage);
                    var exception = error.Exception;
                }
            }

            return errors;
        }

        [NonAction]
        private async Task<ApplicationUser> GetUser()
        {
            return await _userManager.GetUserAsync(User);
        }

        private bool IsPermitted(string key)
        {
            // return true; // todo: - remove whent test is done. 

            if (User.IsInRole(supAdminRole)) return true;
            if (key == SharedKey) return true;

            return false;
        }

        // get sharedkey/setupid
        protected string SharedKey
        {
            get
            {
                return User.Claims.FirstOrDefault(c => c.Type == "Key").Value ?? "";
            }
        }

        // get logged in user id
        protected Guid UserId
        {
            get
            {
                Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid val);

                return val;
            }
        }

    }
}
