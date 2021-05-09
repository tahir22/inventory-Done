using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("PurchaseOrders")]
    public class PurchaseOrder : DomainBaseEntity
    {
        public string OrderNumber { get; set; }
        public string SupplierOrderNumber { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }

        // TODO: for now use 'Supplier' property
        //public string SupplierAddress1 { get; set; }
        //public string SupplierAddress2 { get; set; }
        //public string SupplierCity { get; set; }
        //public string SupplierState { get; set; }
        //public string SupplierCountry { get; set; }
        //public string SupplierPostalCode { get; set; }

        // TODO: leave it for now
        //public string ShipToAddress1 { get; set; }
        //public string ShipToAddress2 { get; set; }
        //public string ShipToCity { get; set; }
        //public string ShipToState { get; set; }
        //public string ShipToCountry { get; set; }
        //public string ShipToPostalCode { get; set; }
        //public string ShipToCompanyName { get; set; }
        //public string ShipToAddressRemarks { get; set; }

        public string SummaryLinePermutation { get; set; }
        public string SupplierAddressRemarks { get; set; }
        public string OrderRemarks { get; set; }
        public string ReceiveRemarks { get; set; }
        public string ReturnRemarks { get; set; }
        public string UnstockRemarks { get; set; }

        // TODO: ignore tax for now
        //public string Tax1Name { get; set; }
        //public string Tax2Name { get; set; }
        //public decimal OrderTax1 { get; set; }
        //public decimal OrderTax2 { get; set; }
        //public decimal? Tax1Rate { get; set; }
        //public decimal? Tax2Rate { get; set; }
        //public decimal ReturnTax1 { get; set; }
        //public decimal ReturnTax2 { get; set; }
        //public bool CalculateTax2OnTax1 { get; set; }
        //public bool Tax1OnShipping { get; set; }
        //public bool? Tax2OnShipping { get; set; }

        public decimal OrderTotal { get; set; }
        public decimal OrderSubTotal { get; set; }
        public decimal? OrderExtra { get; set; }
        public decimal Balance { get; set; }
        public decimal ReturnSubTotal { get; set; }
        public decimal? ReturnExtra { get; set; }
        public decimal ReturnTotal { get; set; }
        public decimal ReturnFee { get; set; }
        public decimal? AncillaryExpenses { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Total { get; set; }

        public int Version { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PurchaseOrderStatus OrderStatus { get; set; } 

        //public bool AncillaryIsPercent { get; set; }
        //public bool? ShowShipping { get; set; }
        //public bool IsTaxInclusive { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsCompleted { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime? RequestShipDate { get; set; }
        public DateTime? DueDate { get; set; }

        public decimal AmountPaid { get; set; }

        //public string Carrier { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        public virtual Location Location { get; set; }
        
        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        //public int CurrencyId { get; set; }
        //public virtual GlobalCurrency Currency { get; set; }

        //public Guid? PaymentTermsId { get; set; }
        //public virtual BasePaymentTerms PaymentTerms { get; set; }

        //public int TaxingSchemeId { get; set; }
        //public virtual BaseTaxingScheme TaxingScheme { get; set; }

        public virtual ICollection<PurchaseOrderAttachment> PurchaseOrderAttachments { get; set; }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        public virtual ICollection<PurchaseOrderReceiveItem> PurchaseOrderReceiveItems { get; set; }
        public virtual ICollection<PurchaseOrderReturnItem> PurchaseOrderReturnItems { get; set; }
        public virtual ICollection<PurchaseOrderUnstockItem> PurchaseOrderUnstockItems  { get; set; }
    }
}
 