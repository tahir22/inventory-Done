using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public class ColumnDefinition
    {
        public string table_name { get; set; }
        public int ordinal_position { get; set; }
        public string column_name { get; set; }
        public string table_catalog { get; set; }
        public string table_schema { get; set; }
        public string column_default { get; set; }
        public string is_nullable { get; set; }
        public string data_type { get; set; }
        public string character_maximum_length { get; set; }
        public string udt_name { get; set; }
        public string is_self_referencing { get; set; }
        public string is_identity { get; set; }
        public string is_updatable { get; set; } 
    }
}
