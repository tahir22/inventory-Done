using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public class DbMetaService : IDbMetaService
    {
        NpgsqlConnection connection = new NpgsqlConnection(); 
        public DbMetaService(IConfiguration config)
        {
             connection = new NpgsqlConnection(config["ConnectionStrings:DefaultConnection"]);
        }

        public async Task<IEnumerable<TableDefinition>> GetTablesAsync()
        {
            var sql = $@"
                    select * from INFORMATION_SCHEMA.tables  
                        WHERE table_schema = ANY (current_schemas(false));
                ";
             
            try
            {
                await connection.OpenAsync();
                var data = connection.Query<TableDefinition>(sql);
                await connection.CloseAsync();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ViewDefinition>> GetViewsAsync()
        {
            var sql = $@"
                    select * from INFORMATION_SCHEMA.views
                        WHERE table_schema = ANY (current_schemas(false));
                ";

            try
            {
                await connection.OpenAsync();
                var data = connection.Query<ViewDefinition>(sql);
                await connection.CloseAsync();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ColumnDefinition>> GetColumnsAsync(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName)) return new List<ColumnDefinition>();

            var sql = $@"
                    SELECT* FROM get_table_definition('{tableName}')
                ";

            try
            {
                await connection.OpenAsync();
                var data = connection.Query<ColumnDefinition>(sql);
                await connection.CloseAsync();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RoutineDefinition>> GetProceduresAsync()
        {
           // if (string.IsNullOrWhiteSpace(tableName)) return new List<ColumnDefinition>();

            var sql = $@"
                    SELECT * FROM information_schema.routines 
                        WHERE (routine_type='PROCEDURE') AND specific_schema='public';
                ";

            try
            {
                await connection.OpenAsync();
                var data = connection.Query<RoutineDefinition>(sql);
                await connection.CloseAsync();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RoutineDefinition>> GetFunctionsAsync()
        {
            // if (string.IsNullOrWhiteSpace(tableName)) return new List<ColumnDefinition>();

            var sql = $@"
                    SELECT * FROM information_schema.routines 
                        WHERE (routine_type='FUNCTION') AND specific_schema='public';
                ";

            try
            {
                await connection.OpenAsync();
                var data = connection.Query<RoutineDefinition>(sql);
                await connection.CloseAsync();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
