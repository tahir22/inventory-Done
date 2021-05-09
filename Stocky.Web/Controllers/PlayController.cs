using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    [Route("api/play"), AllowAnonymous, ApiController]
    //public class PlayController : ODataController
    public class PlayController : ControllerBase
    {
        private AppDbContext context;

        public PlayController(AppDbContext ctx)
        {
            context = ctx;
        }

        [HttpGet("")]
        public IEnumerable<string> EntityList()
        {
            return new List<string>
            {
                "Brands",
                "Categories",
                "Products",
                "Customers",
                "Images",
                "Locations",
                "PurchaseOrderItems",
                "PurchaseOrders",
                "Suppliers",
                "TransactionHistory",
                "SaleOrders",
                "SaleOrderItems", 
                "Tags",
                "Stocks",
                "SupplierItems",
                "StockAdjustments",
                "StockAdjustmentItems",
                "StockAdjustmentAttachments", 
                "Colors",
                "Sizes",
                "Staffs",
            };
        }


        [HttpGet("Staffs"), EnableQuery()]
        public IEnumerable<Staff> Staffs()
        {
            return context.Staffs.AsNoTracking();
        } 
        
        [HttpGet("Sizes"), EnableQuery()]
        public IEnumerable<Size> Sizes()
        {
            return context.Sizes.AsNoTracking();
        } 
        
        [HttpGet("Colors"), EnableQuery()]
        public IEnumerable<Color> Colors()
        {
            return context.Colors.AsNoTracking();
        } 
         
        [HttpGet("StockAdjustmentAttachments"), EnableQuery()]
        public IEnumerable<StockAdjustmentAttachment> StockAdjustmentAttachments()
        {
            return context.StockAdjustmentAttachments.AsNoTracking();
        } 

        [HttpGet("StockAdjustmentItems"), EnableQuery()]
        public IEnumerable<StockAdjustmentItem> StockAdjustmentItems()
        {
            return context.StockAdjustmentItems.AsNoTracking();
        } 
         
        [HttpGet("StockAdjustments"), EnableQuery()]
        public IEnumerable<StockAdjustment> StockAdjustments()
        {
            return context.StockAdjustments.AsNoTracking();
        } 
         
        [HttpGet("ProductSuppliers"), EnableQuery()]
        public IEnumerable<SupplierItem> ProductSuppliers()
        {
            return context.SupplierItems.AsNoTracking();
        } 
         
        [HttpGet("Stocks"), EnableQuery()]
        public IEnumerable<Stock> Stocks()
        {
            return context.Stocks.AsNoTracking();
        } 
         
        [HttpGet("Tags"), EnableQuery()]
        public IEnumerable<Tag> Tags()
        {
            return context.Tags.AsNoTracking();
        } 
         
        [HttpGet("SaleOrderItems"), EnableQuery()]
        public IEnumerable<SaleOrderItem> SaleOrderItems()
        {
            return context.SaleOrderItems.AsNoTracking();
        }
        
        [HttpGet("SaleOrders"), EnableQuery()]
        public IEnumerable<SaleOrder> SaleOrders()
        {
            return context.SaleOrders.AsNoTracking();
        }

        [HttpGet("TransactionHistory"), EnableQuery()]
        public IEnumerable<TransactionHistory> TransactionHistory()
        {
            return context.Transactions.AsNoTracking();
        }
        
        [HttpGet("Suppliers"), EnableQuery()]
        public IEnumerable<Supplier> Suppliers()
        {
            return context.Suppliers.AsNoTracking();
        }
        
        [HttpGet("PurchaseOrders"), EnableQuery()]
        public IEnumerable<PurchaseOrder> PurchaseOrders()
        {
            return context.PurchaseOrders.AsNoTracking();
        }
        
        [HttpGet("PurchaseOrderItems"), EnableQuery()]
        public IEnumerable<PurchaseOrderItem> PurchaseOrderItems()
        {
            return context.PurchaseOrderItems.AsNoTracking();
        }
        
        [HttpGet("Locations"), EnableQuery()]
        public IEnumerable<Location> Locations()
        {
            return context.Locations.AsNoTracking();
        }
        
        [HttpGet("Images"), EnableQuery()]
        public IEnumerable<Image> Images()
        {
            return context.Images.AsNoTracking();
        }
        
        [HttpGet("Customers"), EnableQuery()]
        public IEnumerable<Customer> Customers()
        {
            return context.Customers.AsNoTracking();
        }
        
        [HttpGet("Products"), EnableQuery()]
        public IEnumerable<Product> Products()
        {
            return context.Products.AsNoTracking();
        }

        [HttpGet("Categories"), EnableQuery()]
        public IEnumerable<Category> Categories()
        {
            return context.Categories.AsNoTracking();
        }
        
        [HttpGet("brands"), EnableQuery()]
        public IEnumerable<Brand> Brands()
        {
            return context.Brands.AsNoTracking();
        }
    }
}
