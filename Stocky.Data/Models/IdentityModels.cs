using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Stocky.Data.Entities;

namespace Stocky.Data.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public string SharedKey { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        // Audit Properties 
        public Guid? CreatedBy { get; set; } 
        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public abstract class BaseId 
    {
        public Guid Id { get; set; }
    }

    public class UserModel : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();
        public IEnumerable<Claim> Claims { get; set; } = new List<Claim>();
        public string AvatarURL { get; set; }
    }

    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class PermissionListModel
    {
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        //public bool OnlyForOwner { get; set; }
    }

    public class RoleCreateModel
    {
        [Required, MaxLength(100)]
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }

    public class RoleListModel : BaseId
    { 
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class RoleUpdateModel : BaseId
    { 

        [Required, StringLength(450)]
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<string> Claims { get; set; }
    }

    public class UserCreateModel
    {
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string Avatar { get; set; }

        public bool IsOwner { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();
        //public IEnumerable<Claim> Claims { get; set; } = new List<Claim>();
    }

    public class UserInfoModel : BaseId
    { 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string PhoneNumber { get; set; }
        public string AvatarURL { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public IEnumerable<Image> Images { get; set; }
        public IEnumerable<RoleListModel> Roles { get; set; } = new List<RoleListModel>();
        public IEnumerable<PermissionListModel> Claims { get; set; } = new List<PermissionListModel>();
    }

    public class UserListModel : BaseId
    { 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Avatar { get; set; }

        public Guid? CreatedBy { get; set; }
        //public IEnumerable<string> Roles { get; set; } = new List<string>();
        //public IEnumerable<Claim> Claims { get; set; } = new List<Claim>();
    }

    public class UserUpdateModel : BaseId
    { 
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public IFormFile Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<string> Roles { get; set; } = new List<string>();
    }

    public abstract class IdentityResourceParameters
    {
        const int maxPageSize = 100;

        private int _pageSize = 10;
        public int PageNo { get; set; } = 1;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string SearchQuery { get; set; }
        public string Key { get; set; }
        public string OrderBy { get; set; }
    }

    public class RoleResourceParameters : IdentityResourceParameters
    {
        public string Name { get; set; }
    }

    public class UserResourceParameters : IdentityResourceParameters
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
}
