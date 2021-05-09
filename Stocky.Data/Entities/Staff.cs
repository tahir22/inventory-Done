using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    public class Staff : DomainBaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [ForeignKey("Staff")]
        public Guid? ManagerId { get; set; }
        public Staff Manager { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        public Location Location { get; set; }
    }

}
