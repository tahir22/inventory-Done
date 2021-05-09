using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("Category")]
    public class Category : DomainBaseEntity
    {
        // ProductTypeId, TypeName, TypeDescription						
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(2500)]
        public string Description { get; set; }

        [StringLength(150)]
        public string Icon { get; set; }

        [ForeignKey("ParentCategory")]
        public Guid? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
