using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class CountSheetItemVersion : DomainBaseEntity
    {
        public int Version { get; set; }
        public string Description { get; set; }
        public string Sublocation { get; set; }
        public decimal? SnapshotQty { get; set; }
        public decimal? CountedQty { get; set; }
        public string SnapshotSerials { get; set; }
        public string CountedSerials { get; set; }
        public string CountedQuantityUom { get; set; }
        public decimal? CountedQuantityDisplay { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }

        [ForeignKey("CountSheet")]
        public Guid? CountSheetId { get; set; }
        public virtual CountSheet CountSheet { get; set; }

        [ForeignKey("CountSheetItem")]
        public Guid? CountSheetItemId { get; set; }
        public virtual CountSheetItem CountSheetItem { get; set; }
    }
}
