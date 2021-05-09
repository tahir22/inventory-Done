using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class PurchaseOrderAttachment : DomainBaseEntity
    {
        [ForeignKey("Attachment")]
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }

        [ForeignKey("PurchaseOrder")]
        public Guid PurchaseOrderId { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
