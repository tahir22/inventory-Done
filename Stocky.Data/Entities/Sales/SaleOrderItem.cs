using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("SaleOrderItems")]
    public class SaleOrderItem : DomainBaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("SaleOrder")]
        public Guid? SaleOrderId { get; set; }
        public SaleOrder SaleOrder { get; set; }
    }

}
