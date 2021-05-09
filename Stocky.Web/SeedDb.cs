using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Stocky.Data;
using Stocky.Data.Entities;
using Stocky.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stocky
{
    public static class Seeddb
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Super Admin  
                var superAdmin = await CreateSuperAdmin(serviceProvider);
                await CreateRoles(serviceProvider, superAdmin, Permissions.SuperAdminRole);

                SeedPermissions(context, serviceProvider);
                RefreshApplicationState(context);
                await SeedAppData.Seed(context, superAdmin);
                await SeedSQLAsync(serviceProvider);
            }
        }

        private static async Task<ApplicationUser> CreateSuperAdmin(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            string SuperAdminEmail = Constants.SuperAdminEmail;
            string SuperAdminUserName = Constants.SuperAdminUserName;

            var user = await userManager.FindByNameAsync(SuperAdminUserName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = SuperAdminUserName,
                    Email = SuperAdminEmail,
                    SharedKey = Constants.SuperAdminKey,
                    Id = Constants.SuperAdminId
                };

                await userManager.CreateAsync(user, Constants.SuperAdminPassword);
            }

            return user;
        }

        private static async Task<IdentityResult> CreateRoles(IServiceProvider serviceProvider, ApplicationUser user, string roleName = null)
        {
            IdentityResult IdResult = null;
            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            var permissionRepo = serviceProvider.GetService<IPermissionService>();

            var superAdmin = Constants.SuperAdminRole;
            var superAdminRole = new ApplicationRole
            {
                Name = superAdmin,
                CreatedBy = user.Id,
                SharedKey = user.SharedKey + "_opac",
                IsActive = true,
                DisplayName = "Super Admin"
            };

            var admin = "admin-" + user.SharedKey.Substring(0, 12);
            var adminRole = new ApplicationRole
            {
                Name = admin,
                CreatedBy = user.Id,
                SharedKey = user.SharedKey,
                IsActive = true,
                DisplayName = "Admin"
            };

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(superAdmin))
            {
                IdResult = await roleManager.CreateAsync(superAdminRole);
                if (IdResult.Succeeded)
                    IdResult = await roleManager.CreateAsync(adminRole);
            }

            IdResult = await userManager.AddToRoleAsync(user, superAdminRole.Name);
            IdResult = await userManager.AddToRoleAsync(user, adminRole.Name);
            var allPermissions = permissionRepo.GetAllPermissions();

            foreach (string claim in allPermissions.Distinct())
            {
                //var result = await _roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Name, claim.Value)); 
                var result = await roleManager.AddClaimAsync(superAdminRole, new Claim(CustomClaimTypes.Permission, claim));
            }

            return IdResult;
        }

        public static void SeedPermissions(AppDbContext context, IServiceProvider serviceProvider)
        {
            var permissionRepo = serviceProvider.GetService<IPermissionService>();

            if (!context.ApplicationClaims.Any())
            {
                var defPermissions = permissionRepo.GetAllPermissions();
                context.ApplicationClaims.AddRange(defPermissions);
            }

            context.SaveChanges();
        }

        public static void RefreshApplicationState(AppDbContext context)
        {
            try
            {
                string contentPath = Path.Combine(Directory.GetCurrentDirectory(), $"");
                if (Directory.Exists(contentPath) == false) Directory.CreateDirectory(contentPath);

                var userImages = context.Images.Where(x => x.User != null).Include(x => x.User).ToList();
                var imagePath = $"wwwroot/media";

                foreach (var image in userImages)
                {
                    var fileDir = $"{contentPath}/{imagePath}/{image.SharedKey}/avatars";
                    if (Directory.Exists(fileDir) == false) Directory.CreateDirectory(fileDir);

                    var ext = Path.GetExtension(image.Name);
                    var fileName = $"{image.Id}{ext}";

                    var storePath = $"{fileDir}/{fileName}";
                    System.IO.File.WriteAllBytes(storePath, image.Data);
                }
            }
            catch (Exception)
            {
                //throw;
            }
        }

        public static async Task SeedSQLAsync(IServiceProvider serviceProvider)
        {
            try
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                if (config == null) return;

                var connectionStr = config["ConnectionStrings:DefaultConnection"];
                NpgsqlConnection connection = new NpgsqlConnection(connectionStr);
                await connection.OpenAsync();

                Sql sql = new Sql();
                await connection.ExecuteAsync(sql.Views);
                await connection.ExecuteAsync(sql.Procedures);
                await connection.ExecuteAsync(sql.Functions);

                connection.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
