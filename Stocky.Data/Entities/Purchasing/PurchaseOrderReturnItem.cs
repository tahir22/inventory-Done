using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class PurchaseOrderReturnItem : DomainBaseEntity
    { 
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }

        public DateTime ReturnDate { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
        public string VendorItemCode { get; set; }
        public string QuantityUom { get; set; }
        public decimal? QuantityDisplay { get; set; }
        public string Serials { get; set; }
        public bool? DiscountIsPercent { get; set; }
         
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("PurchaseOrder")]
        public Guid PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }

        //public decimal Tax1Rate { get; set; }
        //public decimal Tax2Rate { get; set; }
        //public int TaxCodeId { get; set; }
        //public virtual BaseTaxCode TaxCode { get; set; }
    }
}
