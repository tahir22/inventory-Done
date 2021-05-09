using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        string SharedKey { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }

        Guid? CreatedBy { get; set; }
        Guid? UpdatedBy { get; set; }
         
        DateTime? UpdatedDate { get; set; }
        DateTime? CreatedDate { get; set; }
    }

    public class DomainBaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [JsonIgnore]
        public string SharedKey { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        // Audit Properties // TODO: Need fk here
        public Guid? CreatedBy { get; set; } 
        public Guid? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
