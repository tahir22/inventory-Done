using Stocky.Data;
using Stocky.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stocky.DataAccess.Services
{
    public class PermissionRepository : IPermissionService
    {
        private readonly List<ApplicationClaim> _permissions;

        public PermissionRepository()
        {
            _permissions =  PermissionManager.AllPermissions.ToList();
        }

        public string[] GetAdministrativePermissionValues()
        {
          return new string[] {
              PermissionManager.ManageUsers,
              PermissionManager.DeleteUsers,
              PermissionManager.UpdateUsers,
              PermissionManager.CreateUsers,
              PermissionManager.ManageRoles,
              PermissionManager.AssignRoles,
              PermissionManager.DeleteRoles,
              PermissionManager.UpdateRoles,
              PermissionManager.CreateRoles,
          };
        }

        public IEnumerable<ApplicationClaim> GetAllPermissions()
        {
            return _permissions;
        }

        public string[] GetAllPermissionValues()
        {
            return _permissions.Select(p => p.Value).ToArray(); 
        }

        public ApplicationClaim GetPermissionByName(string permissionName)
        {
            return _permissions.Where(p => p.Name == permissionName).FirstOrDefault(); 
        }

        public ApplicationClaim GetPermissionByValue(string permissionValue)
        {
            return _permissions.FirstOrDefault(p => p.Value == permissionValue); 
        }  
    }
} 