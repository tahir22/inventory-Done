using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public static class Constants
    {

        // Super admin
        public static readonly Guid SuperAdminId = new Guid("b4ccca70-7ad6-4913-92c1-16312ac85dec");
        public static readonly string SuperAdminKey = "5be67d1a-ea22-4499-a6db-b4c9aa75b08f";
        public static readonly string SuperAdminRole = "super-admin-5be67d1a-ea2";
        public static readonly string SuperAdminEmail = "auth@superadmin.com";
        public static readonly string SuperAdminUserName = "superadmin";
        public static readonly string SuperAdminPassword = "Pass@123";
    }

    public static class CustomClaimTypes
    {
        public static readonly string Permission = "permission";
        public static readonly string Configuration = "configuration";
    }

    public static class Permissions 
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";

        public static readonly string ApproveOperationName = "Approve";
        public static readonly string RejectOperationName = "Reject";

        public static readonly string SuperAdminRole = "SuperAdmin";
        public static readonly string AdminRole = "Admin";
        public static readonly string ShopUserRole = "ShopUser";
        public static readonly string ModeratorRole = "Moderator";

        public static readonly string CustomerRole = "Customer";
        public static readonly string SuplierRole = "Suplier";
    }
}
