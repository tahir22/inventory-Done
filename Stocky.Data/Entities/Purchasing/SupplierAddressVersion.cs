using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class SupplierAddressVersion : DomainBaseEntity
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

        public int VendorAddressId { get; set; }
        public int VendorId { get; set; }
    }
}
