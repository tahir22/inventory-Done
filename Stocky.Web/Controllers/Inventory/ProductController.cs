using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stocky.Data;
using Stocky.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    [Route("api/products")]
    public class ProductController : BaseController<Product>
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILoggerFactory loggerFactory, AppDbContext context) : base(context, context.Products)
        {
            _logger = loggerFactory.CreateLogger<ProductController>();
        }

        public override async Task<ActionResult<Product>> Post([FromBody] Product ent)
        {
            // check if product's stock is null..
            if (ent.ProductStocks != null && ent.ProductStocks.Count() > 0)
            {
                foreach (var ps in ent.ProductStocks)
                {
                    ps.SharedKey = SharedKey;
                    ps.CreatedDate = DateTime.Now;
                    ps.IsActive = true;
                    ps.CreatedBy = UserId;

                    ps.Product = ent;
                }

                await _context.Stocks.AddRangeAsync(ent.ProductStocks);
            }
            else if (ent.DefaultLocationId == null)
            {
                // if product has no stock then set default location & stock.
                var location = await GetLocationAsync();

                 if(location != null)
                 {
                    var productStock = new Stock
                        {
                            Quantity = 0,
                            LocationId = location.Id,
                            Product = ent,
                            IsActive = true,
                            CreatedBy = UserId,
                            CreatedDate = DateTime.Now,
                            SharedKey = SharedKey,
                        };
                        
                    await _context.Stocks.AddAsync(productStock);
                 }
            }

           return await base.Post(ent);
        }

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

            var categoryList = _context.Categories
                .AsNoTracking()
                .Where(x => x.SharedKey == SharedKey)
                .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            var brandList = _context.Brands
                .AsNoTracking()
                .Where(x => x.SharedKey == SharedKey)
                .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            var imageList = _context.Images
                .AsNoTracking()
                .Where(x => x.SharedKey == SharedKey)
                .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            var colorList = _context.Colors
                .AsNoTracking()
                .Where(x => x.SharedKey == SharedKey)
                .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            var sizeList = _context.Sizes
                .AsNoTracking()
                .Where(x => x.SharedKey == SharedKey)
                .Select(x => new LookupModel { Id = x.Id, Name = x.Name });

            return new
            {
                locationList,
                supplierList,
                categoryList,
                imageList,
                sizeList,
                brandList,
                colorList,
            };
        }

        #region Helper private methods
        private async Task<Location> GetLocationAsync() 
        {
            return await _context.Locations.FirstOrDefaultAsync(x => x.SharedKey == SharedKey);
        }
        #endregion
    }

}
