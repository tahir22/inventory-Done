using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stocky.Data.Entities;
using Stocky.Data.Models;
using Stocky.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    [Route("api/dbmeta"), AllowAnonymous]
    public class DbMetaController : ControllerBase
    {
        private IDbMetaService dbMetaService;

        public DbMetaController(IDbMetaService dbMetaSvc)
        {
            dbMetaService = dbMetaSvc;
        }

        [HttpGet("")]
        public async Task<object> TestAsync()
        {
            var  tables = await dbMetaService.GetTablesAsync();
            var views = await dbMetaService.GetViewsAsync();
            var procedures = await dbMetaService.GetProceduresAsync();
            var functions = await dbMetaService.GetFunctionsAsync();
            var columns = await dbMetaService.GetColumnsAsync("Products");

            return new
            {
                tables,
                views,
                procedures,
                functions,
                columns
            };
        }

        [HttpPost("csv")]
        public IEnumerable<Customer> LoadFile(IFormFile file)
        {
            var data = new List<Customer>();
            try
            {
                if (file == null) return data;

                data = FileReader<Customer>.ReadFromCSV(file).ToList();
                return data;
            }
            catch (Exception ex)
            {
                var errors =  ex.Data["ErrorList"];
                var exceptionInfo = ex.Data["Message"];
                throw new Exception($"{ex.Message}: {exceptionInfo}");
            }
        }

        [HttpPost("json")]
        public IEnumerable<Supplier> LoadFileJson(IFormFile file)
        {
            var data = new List<Supplier>();
            try
            {
                if (file == null) return data;

                var importedData = FileReader<SupplierImport>.ReadFromJSON(file);
                return importedData.Suppliers;
            }
            catch (Exception)
            {
                throw; 
            }
        }
    }
}
