using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky
{
    public enum PurchaseOrderStatus
    {
        Draft = 0,
        Released = 1,
        Completed = 2,
        Paid = 4
    };

    public enum PaymentStatus
    {
        Draft = 0,
        Released = 1,
        Completed = 2,
        Paid = 4
    };

    public enum CountSheetStatus
    {
        Open = 0,
        InProcess = 1,
        Completed = 2
    };
    
    public enum StockTransferStatus
    {
        Open = 0,
        InProcess = 1,
        Completed = 2
    };

    public enum IsNewOrder
    {
        NO = 0,
        YES = 1
    };

    public enum BarcodeSystem
    {
        ISBN = 0,
        UPC = 1,
        EAN = 2
    };

    public enum ProductSize
    {
        Small = 0,
        Medium = 1,
        Large = 2,
        ExtraLarge = 3
    };

}
