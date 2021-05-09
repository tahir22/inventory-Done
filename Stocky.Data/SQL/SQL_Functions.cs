using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public partial class Sql
    {
        public string Functions
        {
           //  todo: replace with actual functions
            get
            {
                string sql = "";

                // increment
                sql += @"
                       CREATE OR REPLACE FUNCTION increment(i integer) RETURNS integer AS $$
                                BEGIN
                                        RETURN i + 10;
                                END;
                        $$ LANGUAGE plpgsql;
                    ";

                // get_table_definition
                sql += @"
                        CREATE OR REPLACE FUNCTION get_table_definition(tableName Varchar)
                          RETURNS SETOF INFORMATION_SCHEMA.columns AS
                        $BODY$   
                            SELECT * 
	                        from INFORMATION_SCHEMA.columns 
	                        WHERE table_schema = ANY (current_schemas(false))
	                        and table_schema = 'public'
	                        and table_name = tableName;
                        $BODY$
                        LANGUAGE sql;
                    ";
                return sql;
            }
        }
    }
}
