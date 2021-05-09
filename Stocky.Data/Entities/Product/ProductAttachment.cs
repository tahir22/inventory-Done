using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class ProductAttachment : DomainBaseEntity
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; } 
        public virtual Product Product { get; set; }

        [ForeignKey("Attachment")]
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}