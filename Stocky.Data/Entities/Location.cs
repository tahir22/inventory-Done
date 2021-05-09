using System;
using System.Collections.Generic;
using System.Text;
 
namespace Stocky.Data.Entities
{
    public class Location : DomainBaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<StockAdjustmentItem> StockAdjustmentItems { get; set; }
    }
}
