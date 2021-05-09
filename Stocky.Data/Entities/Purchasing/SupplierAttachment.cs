using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class SupplierAttachment : DomainBaseEntity
    {
        [ForeignKey("Attachment")]
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }

        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
