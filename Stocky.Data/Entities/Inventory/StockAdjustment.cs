using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class StockAdjustment : DomainBaseEntity
    {
        public int Version { get; set; }
        public string AdjustmentNumber { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public bool IsCancelled { get; set; }

        public virtual ICollection<StockAdjustmentAttachment> StockAdjustmentAttachments { get; set; }
        public virtual ICollection<StockAdjustmentItem> StockAdjustmentItems  { get; set; }
        public virtual ICollection<StockAdjustmentItemVersion> StockAdjustmentItemVersions { get; set; } 
    }
}
