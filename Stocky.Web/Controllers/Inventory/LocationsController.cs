using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stocky.Data.Entities;

namespace Stocky.Web.Controllers
{
    public class LocationsController : BaseController<Location>
    {
        public LocationsController(AppDbContext context) : base(context, context.Locations) { }
    }

}