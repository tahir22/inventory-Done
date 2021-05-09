using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    public class Stock : DomainBaseEntity
    {
        public int Quantity { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Location")]
        public Guid LocationId { get; set; }
        public Location Location { get; set; }
    }

}
