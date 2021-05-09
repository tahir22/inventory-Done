using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("Tags")]
    public class Tag : DomainBaseEntity
    {
        [StringLength(150)]
        public string Name { get; set; }
    }

}
