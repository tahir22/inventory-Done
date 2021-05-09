using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stocky.Data.Entities;
using Stocky.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    public class PurchaseOrdersController : BaseController<PurchaseOrder>
    {
        public PurchaseOrdersController(AppDbContext context) : base(context, context.PurchaseOrders) { }

        [HttpGet("lookups")]
        public object Lookups()
        {
            var locationList = _context.Locations
              .AsNoTracking()
              .Where(x => x.SharedKey == SharedKey)
              .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            var supplierList = _context.Suppliers
                .AsNoTracking()
                .Where(x => x.SharedKey == SharedKey)
                .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            var productList = _context.Products
                .AsNoTracking()
                .Where(x => x.SharedKey == SharedKey)
                .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            return new
            {
                supplierList,
                productList,
                locationList
            };
        }
    }
}
