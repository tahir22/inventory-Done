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
    public class CountSheetsController : BaseController<CountSheet>
    {
        public CountSheetsController(AppDbContext context) : base(context, context.CountSheets) { }

        // api/CountSheets/GetSnapshot/id
        [HttpGet("GetSnapshot/{id}")]
        public async Task<CountSheet> GetCountSheeSnapshotAsync(Guid id)
        {
            var countSheet = await _context.CountSheets
                .Where(x => x.Id == id).Include(x => x.CountSheetItems)
                //.AsNoTracking()
                .FirstOrDefaultAsync();

            if (countSheet.CountSheetItems != null && countSheet.CountSheetItems.Count() > 1)
            {
                // set countsheet's item stock (snapShotQty).
                foreach (var csi in countSheet?.CountSheetItems)
                {
                    csi.SnapshotQty = GetStockQuantity(csi.LocationId, csi.ProductId);
                }

                // update countsheet's status & snapshotQty.
                countSheet.Status = CountSheetStatus.InProcess;
                await base.Put(id, countSheet);
            }

            return countSheet;
        }

        public override async Task<IActionResult> Put(Guid id, [FromBody] CountSheet countsheet)
        {
            if (countsheet.CountSheetItems != null && countsheet.CountSheetItems.Count() > 0)
            {
                // update countsheet's items & Stock.
                foreach (var csi in countsheet?.CountSheetItems)
                {
                    UpdateStockQuantity(csi.LocationId, csi.ProductId, csi.CountedQty ?? 0);

                    csi.UpdatedBy = UserId;
                    csi.UpdatedDate = DateTime.Now;
                    csi.SharedKey = SharedKey;
                    csi.Version += 1;
                }

                _context.CountSheetItems.UpdateRange(countsheet.CountSheetItems);
            }

            // TODO: fix, later
            countsheet.Status = CountSheetStatus.Completed;
            countsheet.IsCompleted = true;
            return await base.Put(id, countsheet);
        }

        #region Helpers
        private void UpdateStockQuantity(Guid? locationId, Guid? productId, decimal Qty)
        {
            var stock = _context.Stocks.FirstOrDefault(x => x.LocationId == locationId && x.ProductId == productId);
            if (stock == null) return;
            stock.Quantity = (int)Qty;

            _context.Stocks.Update(stock);
        }

        private int? GetStockQuantity(Guid? locationId, Guid? productId)
        {
            return _context.Stocks.FirstOrDefault(x => x.LocationId == locationId && x.ProductId == productId)?.Quantity;
        }
        #endregion 

    }
}
