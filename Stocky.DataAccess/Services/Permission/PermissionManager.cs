using Stocky.Data.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.DataAccess.Services
{
    public class PermissionManager
    {
        public static ReadOnlyCollection<ApplicationClaim> AllPermissions;

        #region All Permission List

        public const string UsersPermissionGroupName = "User Permissions";
        public static ApplicationClaim ManageUsers = new ApplicationClaim("Manage Users", "manage-users", UsersPermissionGroupName, "Permission to create, delete and modify other users account details.");

        public static ApplicationClaim ViewUsers = new ApplicationClaim("View Users", "view-users", UsersPermissionGroupName, "Permission to view other users account details.");
        public static ApplicationClaim CreateUsers  = new ApplicationClaim("Create Users", "create-users", UsersPermissionGroupName, "Permission to create users.");
        public static ApplicationClaim UpdateUsers  = new ApplicationClaim("Update Users", "update-users", UsersPermissionGroupName, "Permission to update users.");
        public static ApplicationClaim DeleteUsers = new ApplicationClaim("Delete Users", "delete-users", UsersPermissionGroupName, "Permission to delete users.");


        public const string RolesPermissionGroupName = "Role Permissions";
        public static ApplicationClaim ManageRoles = new ApplicationClaim("Manage Roles", "manage-roles", RolesPermissionGroupName, "Permission to create, delete and modify roles.");
        public static ApplicationClaim AssignRoles = new ApplicationClaim("Assign Roles", "assign-roles", RolesPermissionGroupName, "Permission to assign roles to other users.");
        public static ApplicationClaim ViewRoles = new ApplicationClaim("View Roles", "view-roles", RolesPermissionGroupName, "Permission to view available roles.");
        public static ApplicationClaim CreateRoles = new ApplicationClaim("Create Roles", "create-roles", RolesPermissionGroupName, "Permission to create roles.");
        public static ApplicationClaim UpdateRoles = new ApplicationClaim("Update Roles", "update-roles", RolesPermissionGroupName, "Permission to update roles.");
        public static ApplicationClaim DeleteRoles = new ApplicationClaim("Delete Roles", "delete-roles", RolesPermissionGroupName, "Permission to delete roles.");

         
        public const string ProductGroup = "Products";
        public static ApplicationClaim ProductView = new ApplicationClaim("View Products", "view-products", ProductGroup, "Permission to products.");
        public static ApplicationClaim ProductCreate = new ApplicationClaim("Create Products", "create-products", ProductGroup, "Permission to Create products.");
        public static ApplicationClaim ProductUpdate = new ApplicationClaim("Update Products", "update-products", ProductGroup, "Permission to Update products.");
        public static ApplicationClaim ProductDelete  = new ApplicationClaim("Delete Products", "delete-products", ProductGroup, "Permission to Delete products.");
        #endregion

        #region Construct Permissions 
        static PermissionManager()
        {
            List<ApplicationClaim> allPermissions = new List<ApplicationClaim>()
            {
                ViewUsers,
                CreateUsers,
                UpdateUsers,
                DeleteUsers,
                 
                ViewRoles,
                CreateRoles,
                UpdateRoles,
                DeleteRoles,
                AssignRoles,

                ProductView,
                ProductCreate,
                ProductDelete,
                ProductUpdate,
            };

            #endregion

            AllPermissions = allPermissions.AsReadOnly();
        }
        public static ApplicationClaim GetPermissionByValue(string permissionValue)
        {
            return AllPermissions.FirstOrDefault(p => p.Value == permissionValue);
        }

    } 
}
