using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("PurchaseOrderItems")]
    public class PurchaseOrderItem : DomainBaseEntity
    { 
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

        public int Version { get; set; }
        public string Description { get; set; }
        public string SupplierItemCode { get; set; } 
        public decimal SubTotal { get; set; }
        public string QuantityUom { get; set; }
        public decimal? QuantityDisplay { get; set; }
        public string Serials { get; set; }
        public bool? DiscountIsPercent { get; set; }
        public bool? ServiceCompleted { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("PurchaseOrder")]
        public Guid? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        //public decimal Tax1Rate { get; set; }
        //public decimal Tax2Rate { get; set; }
        //public int TaxCodeId { get; set; }
        //public virtual BaseTaxCode TaxCode { get; set; }
    }
}
