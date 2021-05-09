using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    public class CountSheetAttachment : DomainBaseEntity
    {
        [ForeignKey("CountSheet")] 
        public Guid CountSheetId { get; set; } 
        public virtual CountSheet CountSheet { get; set; } 

        [ForeignKey("Attachment")]
        public Guid AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; } 
    }
}
