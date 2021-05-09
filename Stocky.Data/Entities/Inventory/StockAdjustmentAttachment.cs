using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class StockAdjustmentAttachment : DomainBaseEntity
    {
        [ForeignKey("StockAdjustment")]
        public Guid StockAdjustmentId { get; set; }
        public virtual StockAdjustment StockAdjustment { get; set; }

        [ForeignKey("Attachment")]
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
