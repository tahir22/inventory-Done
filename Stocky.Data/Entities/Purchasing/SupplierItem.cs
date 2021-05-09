using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class SupplierItem : DomainBaseEntity
    {
        public string SupplierItemCode { get; set; }
        public decimal? Cost { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Supplier")]
        public Guid? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
