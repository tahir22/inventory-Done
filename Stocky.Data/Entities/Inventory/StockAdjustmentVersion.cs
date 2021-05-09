using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class StockAdjustmentVersion : DomainBaseEntity
    {
        public int Version { get; set; }
        public string AdjustmentNumber { get; set; }
        public DateTime Date { get; set; }
        public string Remarks { get; set; }
        public bool IsCancelled { get; set; }

        [ForeignKey("StockAdjustment")]
        public Guid StockAdjustmentId { get; set; }
        public StockAdjustment StockAdjustment { get; set; }
    }
}
