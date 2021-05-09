using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stocky
{
    public interface IDbMetaService
    {
        Task<IEnumerable<TableDefinition>> GetTablesAsync();
        Task<IEnumerable<ViewDefinition>> GetViewsAsync();
        Task<IEnumerable<ColumnDefinition>> GetColumnsAsync(string tableName);
        Task<IEnumerable<RoutineDefinition>> GetProceduresAsync();
        Task<IEnumerable<RoutineDefinition>> GetFunctionsAsync();
    }
}
