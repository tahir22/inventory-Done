using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class PurchaseOrderReceiveItem : DomainBaseEntity
    { 
        public decimal Quantity { get; set; }

        public int Version { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string Description { get; set; }
        public string SupplierItemCode { get; set; }
        public string Sublocation { get; set; }
        public string QuantityUom { get; set; }
        public decimal? QuantityDisplay { get; set; }
        public string Serials { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("PurchaseOrder")]
        public Guid PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
