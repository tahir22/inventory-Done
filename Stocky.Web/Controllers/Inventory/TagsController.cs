using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    public class TagsController : BaseController<Tag>
    {
        public TagsController(AppDbContext context) : base(context, context.Tags) { }
    }
}
