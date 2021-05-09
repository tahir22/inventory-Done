using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class StockTransferItem : DomainBaseEntity
    {
        public int Version { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityUom { get; set; }
        public decimal? QuantityDisplay { get; set; }
        public string Serials { get; set; }
        public string FromSublocation { get; set; }
        public string ToSublocation { get; set; }

        [ForeignKey("FromLocation")]
        public Guid FromLocationId { get; set; }
        public virtual Location FromLocation { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("StockTransfer")]
        public Guid StockTransferId { get; set; }
        public virtual StockTransfer StockTransfer { get; set; }

        [ForeignKey("ToLocation")]
        public Guid ToLocationId { get; set; }
        public virtual Location ToLocation { get; set; }

        public virtual ICollection<StockTransferItemVersion> StockTransferItemVersions { get; set; }
    }
}
