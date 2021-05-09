using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stocky.Data.Entities
{
    public class Attachment : DomainBaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Size { get; set; }
        public string AttachmentURL { get; set; }

        [JsonIgnore]
        public byte[] Data { get; set; }
    }
}
