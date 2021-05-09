using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class StockAdjustmentItemVersion : DomainBaseEntity
    {
        public int Version { get; set; }
        public string Description { get; set; }
        public decimal? QuantityBefore { get; set; }
        public string QuantityBeforeUom { get; set; }
        public decimal? QuantityBeforeDisplay { get; set; }
        public decimal? QuantityAfter { get; set; }
        public string QuantityAfterUom { get; set; }
        public decimal? QuantityAfterDisplay { get; set; }
        public decimal? Difference { get; set; }
        public string DifferenceUom { get; set; }
        public decimal? DifferenceDisplay { get; set; }
        public string Serials { get; set; }
        //public string Sublocation { get; set; }

        [ForeignKey("StockAdjustmentItem")]
        public Guid? StockAdjustmentItemId { get; set; } 
        public StockAdjustmentItem StockAdjustmentItem { get; set; } 

        [ForeignKey("StockAdjustment")]
        public Guid? StockAdjustmentId { get; set; }
        public virtual StockAdjustment StockAdjustment { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
