using System;
using System.Collections.Generic;
using System.Text;

namespace Stocky.Data.Models
{
   public class ListModel<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
    }
}
