using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("Suppliers")]
    public class Supplier : DomainBaseEntity
    { 
        public int Version { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AddressRemarks { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public decimal Discount { get; set; }

        //public bool IsTaxInclusivePricing { get; set; }
        //public string Custom1 { get; set; }
        //public string Custom2 { get; set; }
        //public string Custom3 { get; set; }
        //public string Custom4 { get; set; }
        //public string Custom5 { get; set; } 
        //public string DefaultCarrier { get; set; }
        //public AddressType AddressType { get; set; }
        //public string DefaultPaymentMethod { get; set; }

        //public int CurrencyId { get; set; }
        //public virtual GlobalCurrency Currency { get; set; }

        //public int? DefaultPaymentTermsId { get; set; }
        //public virtual BasePaymentTerms DefaultPaymentTerms { get; set; }

        //public int? TaxingSchemeId { get; set; }
        //public virtual BaseTaxingScheme TaxingScheme { get; set; }

        //public virtual ICollection<BaseBatchVendorPayment> BaseBatchVendorPayment { get; set; }
        public virtual ICollection<SupplierAttachment> SupplierAttachments { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SupplierItem> SupplierItems  { get; set; }
        public virtual ICollection<SupplierAddress> SupplierAddresses { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
