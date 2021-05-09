using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    // StoreProcedure & Functions
    public class RoutineDefinition
    {
        public string security_type { get; set; }
        public string sql_data_access { get; set; }
        public string external_language { get; set; }
        public string external_name { get; set; }
        public string routine_definition { get; set; }
        public string routine_body { get; set; }
        public string routine_type { get; set; }
        public string routine_name { get; set; }
        public string routine_schema { get; set; }
        public string routine_catalog { get; set; }
        //public string specific_name { get; set; }
        //public string specific_schema { get; set; }
        //public string specific_catalog { get; set; }
    }
}
