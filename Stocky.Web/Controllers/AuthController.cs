using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Stocky.Data.Entities;
using Stocky.Data.Models;
using Stocky.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public AuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
            _config = config;
        }


        [AllowAnonymous]
        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized("Invalid email or username."); ;
            if (!ModelState.IsValid) return response;

            var user = await Authenticate(login);
            if (user == null) return response;

            var tokenString = await BuildToken(user);
            var loginResult = new
            {
                token = tokenString,
                roles = user.Roles,
                //TODO:  set token expiry, current aim is only for devs. 
                expiresIn = DateTime.Now.AddDays(180),
                requestAt = DateTime.Now,
                token_type = "bearer",
                profile = new
                {
                    user.AvatarURL,
                    user.FirstName,
                    user.LastName,
                    user.Designation,
                    user.UserName
                }
            };

            return Ok(loginResult);
        }

        [NonAction]
        private async Task<string> BuildToken(UserModel user)
        {
            var fullName = $"{user.FirstName} {user.LastName}";

            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, user.UserName),
                    new Claim("Key", user.SharedKey),
                    new Claim("Name", fullName)
                };

            claims.AddRange(user.Claims);
            foreach (var roleName in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));

                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    claims.AddRange(roleClaims);
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims.DistinctBy(c => c.Value),
              //TODO:  set token expiry, current aim is only for devs. 
              expires: DateTime.Now.AddDays(180),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [NonAction]
        private async Task<UserModel> Authenticate(LoginModel login)
        {
            UserModel userModel = null;
            var user = await _userManager.FindByNameAsync(login.UserName);

            if (user == null)
                user = await _userManager.FindByEmailAsync(login.UserName);

            if (user != null)
            {
                var result = await _signinManager.PasswordSignInAsync(user, login.Password, false, false);

                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var userClaims = await _userManager.GetClaimsAsync(user);

                    userModel = new UserModel
                    {
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        AvatarURL = user.AvatarURL,
                        CreatedDate = DateTime.Now,
                        Designation = user.Designation,
                        Email = user.Email,
                        Id = user.Id,
                        SharedKey = user.SharedKey,
                        Roles = userRoles,
                        Claims = userClaims
                    };
                }
            }

            return userModel;
        }

    }
}


