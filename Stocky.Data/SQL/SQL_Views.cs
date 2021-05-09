using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public partial class Sql
    {

        public string Views
        {
            get
            {
                // TODO: replace below templtes with actual views
                string sql = "";
               
                // product List
               sql += @"
                    CREATE OR REPLACE VIEW public.productlist 
                           AS SELECT * FROM ""Products""; 
                    ";

                // Customer List
                sql += @"
                    CREATE OR REPLACE VIEW public.customerList 
                           AS SELECT * FROM ""Customers"";               
                ";


                return sql;
            }
        }
    }
}
