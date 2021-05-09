using System;
using System.Collections.Generic;
using System.Text;

namespace Stocky.Data.Entities
{
    public class Size : DomainBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Product> Products { get; set; }
    }

}
