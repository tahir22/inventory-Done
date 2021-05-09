using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    public class StockTransferItemsController : BaseController<StockTransferItem>
    {
        public StockTransferItemsController(AppDbContext context) : base(context, context.StockTransferItems) { }
    }
}
