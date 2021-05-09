using Stocky.Data.Entities;
using System.Collections.Generic;

namespace Stocky.DataAccess.Services 
{
    public interface IPermissionService
    {
        ApplicationClaim GetPermissionByName(string permissionName);
        ApplicationClaim GetPermissionByValue(string permissionValue);
        string[] GetAllPermissionValues();
        string[] GetAdministrativePermissionValues();
        IEnumerable<ApplicationClaim> GetAllPermissions();
        //IEnumerable<ApplicationClaim> GetAllPermissionsFromDb();
    }
}
