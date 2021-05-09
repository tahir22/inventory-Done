using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public partial class Sql
    {

        public string Procedures
        {
            get
            {
                // TODO: replace below procedures with actual
           string sql = "";
           sql += @"
            CREATE OR REPLACE PROCEDURE public.get_sample()
                LANGUAGE sql
                AS $procedure$
	                SELECT * from ""Products"";
                $procedure$;
            ";

            // Add another
            sql += @"
            CREATE OR REPLACE PROCEDURE public.get_product_list()
                LANGUAGE sql
                AS $procedure$
	                SELECT * from ""Products"";
                $procedure$;
            ";


                return sql;
            }
        }
    }
}
