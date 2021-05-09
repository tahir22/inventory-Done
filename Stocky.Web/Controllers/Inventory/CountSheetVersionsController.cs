using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    public class CountSheetVersionsController : BaseController<CountSheetVersion>
    {
        public CountSheetVersionsController(AppDbContext context) : base(context, context.CountSheetVersions) { }
    }
}
