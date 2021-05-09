using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class CountSheetVersion : DomainBaseEntity
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
       
        [ForeignKey("CountSheet")]
        public Guid? CountSheetId { get; set; }  
        public CountSheet CountSheet { get; set; }
    }
}
