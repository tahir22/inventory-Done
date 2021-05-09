using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class StockTransfer : DomainBaseEntity
    {
        public int Version { get; set; }
        public string TransferNumber { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public StockTransferStatus Status { get; set; } // enum
        public bool IsCancelled { get; set; }
        public string Remarks { get; set; }
        //public string Custom1 { get; set; }
        //public string Custom2 { get; set; }
        //public string Custom3 { get; set; }

        public virtual ICollection<StockTransferAttachment> StockTransferAttachments { get; set; }
        public virtual ICollection<StockTransferItem> StockTransferItems { get; set; }
        public virtual ICollection<StockTransferVersion> StockTransferVersions  { get; set; }
    }
}
