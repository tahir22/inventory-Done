using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Models
{
    public class SupplierImport
    {
        public IEnumerable<Supplier> Suppliers { get; set; }
    } 
}
