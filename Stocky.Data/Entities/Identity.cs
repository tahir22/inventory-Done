using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Stocky.Data.Entities
{
    [Table("AppClaims")]
    public class ApplicationClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Type { get; set; }

        [StringLength(100)]
        public string Value { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }


        public ApplicationClaim() { }
        public ApplicationClaim(string name, string value, string groupName, string description = null)
        {
            Type = CustomClaimTypes.Permission;
            Name = name;
            Value = value;
            GroupName = groupName;
            Description = description;
        }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(ApplicationClaim claim)
        {
            return claim.Value;
        }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }
        public bool OnlyForOwner { get; set; }
    }

    public class ApplicationUser : IdentityUser<Guid>, IBaseEntity
    {
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }


        public string Designation { get; set; }
        public string FullName { get; set; }
        public string Configuration { get; set; }

        public string AvatarURL { get; set; }

        [StringLength(450)]
        public string SharedKey { get; set; }

        public bool IsActive { get; set; }
        public bool IsOwner { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        //public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }  
        //public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }  
    }

    public class ApplicationRole : IdentityRole<Guid>, IBaseEntity
    {
        public ApplicationRole(string role) : base(role) { }

        public ApplicationRole() { }

        //public virtual IList<IdentityUserRole<string>> Users { get; set; } = new List<IdentityUserRole<string>>();
        //public virtual IList<IdentityRoleClaim<string>> Claims { get; set; } = new List<IdentityRoleClaim<string>>();
        [StringLength(450)]
        public string SharedKey { get; set; }

        [StringLength(450)]
        public string DisplayName { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }

    public class RoleClaim : IdentityRoleClaim<Guid> { }
    public class UserClaim : IdentityUserClaim<Guid> { }
    public class UserLogin : IdentityUserLogin<Guid> { }
    public class UserRole : IdentityUserRole<Guid> { }
    public class UserToken : IdentityUserToken<Guid> { }

}
