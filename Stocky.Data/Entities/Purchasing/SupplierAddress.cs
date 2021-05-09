using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class SupplierAddress : DomainBaseEntity
    { 
        public int Version { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AddressRemarks { get; set; }  

        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
