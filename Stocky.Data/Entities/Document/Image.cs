using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    // Image
    public class Image : DomainBaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string ContentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public string ImageURL { get; set; }

        [JsonIgnore]
        public byte[] Data { get; set; }

        [ForeignKey("User")]
        public Guid? UserId { get; set; }
        public ApplicationUser User { get; set; }
    }

}
