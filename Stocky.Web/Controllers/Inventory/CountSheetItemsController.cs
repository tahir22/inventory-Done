using Microsoft.AspNetCore.Mvc;
using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    public class CountSheetItemsController : BaseController<CountSheetItem>
    {
        public CountSheetItemsController(AppDbContext context) : base(context, context.CountSheetItems) { }

        [HttpGet("lookups")]
        public object Lookups()
        {
            var locaionList = _context.Locations.Where(x => x.SharedKey == SharedKey);
            var countsheetList = _context.CountSheets.Where(x => x.SharedKey == SharedKey);
            var productList = _context.Products.Where(x => x.SharedKey == SharedKey); 

            return new
            {
                locaionList,
                countsheetList,
                productList
            };
        }
    }
}
