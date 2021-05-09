﻿using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    public class StockTransferAttachmentsController : BaseController<StockTransferAttachment>
    {
        public StockTransferAttachmentsController(AppDbContext context) : base(context, context.StockTransferAttachments) { }
    }
}
