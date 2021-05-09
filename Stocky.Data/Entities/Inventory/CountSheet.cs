using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class CountSheet : DomainBaseEntity
    {
        public int Version { get; set; }
        public string CountSheetNumber { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CountedBy { get; set; }
        public DateTime? SnapshotDttm { get; set; }
        public DateTime? AdjustmentDttm { get; set; }
        public CountSheetStatus Status { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsCompleted { get; set; }
        public string Remarks { get; set; }
         
        public virtual IList<CountSheetAttachment> CountSheetAttachments { get; set; }
        public virtual IList<CountSheetItem> CountSheetItems { get; set; } 
        public virtual IList<CountSheetVersion> CountSheetVersions { get; set; }
    } 
}
