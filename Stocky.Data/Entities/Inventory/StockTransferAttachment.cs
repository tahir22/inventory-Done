using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class StockTransferAttachment : DomainBaseEntity
    {
        [ForeignKey("StockTransfer")]
        public Guid StockTransferId { get; set; }
        public virtual StockTransfer StockTransfer { get; set; } 

        [ForeignKey("Attachment")]
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
