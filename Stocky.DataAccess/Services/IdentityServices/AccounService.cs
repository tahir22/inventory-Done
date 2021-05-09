using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Stocky;
using Stocky.Data.Entities;
using Stocky.Data.Models;
using Stocky.DataAccess.Services;
using Stocky.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.IdentityServices
{
    public interface IAccounService
    {
        Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
        Task<bool> CreateDefaultPermissions(ApplicationUser owner, Guid userId);
        Task<IdentityResult> DeleteRoleAsync(ApplicationRole role);
        IQueryable<RoleListModel> FilterRoles(IQueryable<RoleListModel> roles, RoleResourceParameters parameters);
        IQueryable<UserListModel> FilterUsers(IQueryable<UserListModel> users, UserResourceParameters parameters);
        Task<IEnumerable<RoleListModel>> GetUserRolesAsync(ApplicationUser user);
        Task<IEnumerable<PermissionListModel>> GetUserPermissionsAsync(ApplicationUser user);
        Task<IEnumerable<object>> GetRolePermissionsAsync(ApplicationRole role);
        Task<IEnumerable<UserListModel>> GetRoleUsersAsync(string role);
        Task<Result> UpdateUserAsync(ApplicationUser user, IEnumerable<string> roles);

    }

    public class AccounService : IAccounService
    {
        public static string supAdminRole = "super-admin";
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccounService> _logger;
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissions;

        #region constructor
        public AccounService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IPermissionService permission,
            IMapper mapper,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccounService>();
            _mapper = mapper;
            _permissions  = permission;
        }
        #endregion
         
        public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            var idResult = new IdentityResult();

            try
            {
                if (user == null) return idResult;
                idResult = await _userManager.DeleteAsync(user);
                return idResult;
            }
            catch
            {
                //Todo:  log detail
            }

            return idResult;
        }

        public async Task<bool> CreateDefaultPermissions(ApplicationUser owner, Guid userId)
        {
            if (owner == null) return false;

            IdentityResult IdResult = null;
            try
            {
                var defOwnerRole = "owner-" + owner.SharedKey.Substring(0, 12);
                var defAdminRole = "admin-" + owner.SharedKey.Substring(0, 12);

                var ownerRole = new ApplicationRole
                {
                    Name = defOwnerRole,
                    DisplayName = "Owner",
                    SharedKey = owner.SharedKey + "_opac",
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };

                var adminRole = new ApplicationRole
                {
                    Name = defAdminRole,
                    DisplayName = "Admin",
                    SharedKey = owner.SharedKey,
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false
                };

                IdResult = await _roleManager.CreateAsync(ownerRole);

                if (IdResult.Succeeded) IdResult = await _roleManager.CreateAsync(adminRole);
                if (IdResult.Succeeded) IdResult = await _userManager.AddToRoleAsync(owner, defAdminRole);
                if (IdResult.Succeeded) IdResult = await _userManager.AddToRoleAsync(owner, defOwnerRole);

                if (IdResult.Succeeded)
                {
                    var defOwnerClaims = _permissions.GetAllPermissions().Distinct();

                    var role = await _roleManager.FindByNameAsync(defOwnerRole);
                    foreach (var claim in defOwnerClaims)
                    {
                        //var result = await _roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Name, claim.Value)); 
                        var result = await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, claim.Value)); // (type, value)

                        if (!result.Succeeded) return false;
                    }

                }

            }
            catch (Exception)
            {
            }

            return IdResult.Succeeded;
        }
        public async Task<IdentityResult> DeleteRoleAsync(ApplicationRole role)
        {
            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded) return result;

            return result;
        }

        public IQueryable<RoleListModel> FilterRoles(IQueryable<RoleListModel> roles, RoleResourceParameters parameters)
        {
            #region Filter, Search & sort
            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                var name = parameters.Name.Trim().ToLowerInvariant();
                roles = roles.Where(r => r.Name.ToLowerInvariant().Contains(name));
            }


            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                var searchQueryForWhereClause = parameters.SearchQuery.Trim().ToLowerInvariant();

                roles = roles
                    .Where(r => r.DisplayName.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || r.DisplayName.ToLowerInvariant().Contains(searchQueryForWhereClause));
            }
            #endregion


            return roles;
        }
        public IQueryable<UserListModel> FilterUsers(IQueryable<UserListModel> users, UserResourceParameters parameters)
        {
            #region Filter, Search & sort
            //if (!string.IsNullOrWhiteSpace(parameters.Name))
            //{
            //    var name = parameters.Name.Trim().ToLowerInvariant();
            //    users = users.Where(u => u.FirstName.ToLowerInvariant().Contains(name));
            //}


            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                var searchQueryForWhereClause = parameters.SearchQuery.Trim().ToLowerInvariant();

                users = users
                    .Where(u => u.FirstName.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || u.LastName.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || u.Email.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || u.Designation.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || u.PhoneNumber.ToLowerInvariant().Contains(searchQueryForWhereClause)
                    || u.LastName.ToLowerInvariant().Contains(searchQueryForWhereClause));
            }
            #endregion


            return users;
        }
        public async Task<IEnumerable<RoleListModel>> GetUserRolesAsync(ApplicationUser user)
        {
            var userRoles = new List<RoleListModel>();
            if (user == null) return userRoles;

            var roleNames = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles
                .Where(r => roleNames.Contains(r.Name) && r.IsActive && !r.IsDeleted && r.SharedKey == user.SharedKey);

            userRoles = _mapper.Map<IEnumerable<RoleListModel>>(roles).ToList();
            return userRoles;
        }
        public async Task<IEnumerable<PermissionListModel>> GetUserPermissionsAsync(ApplicationUser user)
        {
            var userClaims = new List<PermissionListModel>();
            if (user == null) return userClaims;

            var roleNames = await _userManager.GetRolesAsync(user);
            IEnumerable<Claim> userAssignedClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>();
            claims.AddRange(userAssignedClaims);

            foreach (var roleName in roleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    claims.AddRange(roleClaims);
                }
            }

            var permissions = _permissions.GetAllPermissions();
            var userOwnedClaims = claims.DistinctBy(c => c.Value).Select(c => c.Value);

            var userClaimList = permissions.Where(p => userOwnedClaims.Contains(p.Value)).ToList();

            return _mapper.Map<IEnumerable<PermissionListModel>>(userClaimList);
        }
        public async Task<IEnumerable<object>> GetRolePermissionsAsync(ApplicationRole role)
        {
            var roleClaimsList = new List<PermissionListModel>();
            if (role == null) return roleClaimsList;

            var claims = await _roleManager.GetClaimsAsync(role);
            if (!claims.Any()) return roleClaimsList;

            var permissions = _permissions.GetAllPermissions();
            var roleAssingedClaims = claims.DistinctBy(c => c.Value).Select(c => c.Value);

            var roleClaims = permissions.Where(p => roleAssingedClaims.Contains(p.Value)).ToList();

            var permissionList = _mapper.Map<IEnumerable<PermissionListModel>>(roleClaims);

            var permissionGroups = permissionList.GroupBy(x => x.GroupName);
            var permissionGroupList = new List<object>();
            foreach (var permission in permissionGroups)
            {
                var permissionItem = new
                {
                    Group = permission.Key,
                    Permissions = permission
                };

                permissionGroupList.Add(permissionItem);
            }

            return permissionGroupList;
        }
        public async Task<IEnumerable<UserListModel>> GetRoleUsersAsync(string role)
        {
            var roleUsers = new List<UserListModel>();
            if (role == null) return roleUsers;

            var userList = await _userManager.GetUsersInRoleAsync(role);
            roleUsers = _mapper.Map<IEnumerable<UserListModel>>(userList).ToList();

            return roleUsers;
        }
        public async Task<Result> UpdateUserAsync(ApplicationUser user, IEnumerable<string> roles)
        {
            // todo: - fix update isseus, who 
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return new Result()
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description).ToArray()
                };
            };

            if (roles.Any())
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var rolesToRemove = userRoles.Except(roles).ToArray();
                var rolesToAdd = roles.Except(userRoles).Distinct().ToArray();

                if (rolesToRemove.Any())
                {
                    result = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    if (!result.Succeeded)
                    {
                        return new Result()
                        {
                            Success = false,
                            Errors = result.Errors.Select(e => e.Description).ToArray()
                        };
                    }
                }

                var rolesInDb = _roleManager.Roles.Select(x => x.Name).ToList();
                rolesToAdd = rolesToAdd.Where(r => rolesInDb.Contains(r)).ToArray(); // exclude roles if not exist. 

                if (rolesToAdd.Any())
                {
                    result = await _userManager.AddToRolesAsync(user, rolesToAdd);
                    if (!result.Succeeded)
                    {
                        return new Result()
                        {
                            Success = false,
                            Errors = result.Errors.Select(e => e.Description).ToArray()
                        };
                    }
                }
            }

            return new Result() { Success = true };
        }
    }
}
