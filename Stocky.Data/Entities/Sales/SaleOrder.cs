using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("SaleOrders")]
    public class SaleOrder : DomainBaseEntity
    {
        [StringLength(50)]
        public string OrderReference { get; set; }
        public decimal TotalAmount { get; set; }

        [StringLength(2000)]
        public string Comments { get; set; }

        [ForeignKey("Customer")]
        public Guid? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [EnumDataType(typeof(PurchaseOrderStatus))]
        public PurchaseOrderStatus Status { get; set; } // enum
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; }
        public Location Location { get; set; }

        [ForeignKey("Staff")]
        public Guid? StaffId { get; set; }
        public Staff Staff { get; set; }

        // Customer details in case customer is not registered
        [MaxLength(150)]
        public string CustomerName { get; set; }

        [MaxLength(500)]
        public string CustomerAddress { get; set; }

        [MaxLength(30)]
        public string CustomerPhone { get; set; }

        [MaxLength(30)]
        public string CustomerMobile { get; set; }

        [MaxLength(100)]
        public string CustomerEmail { get; set; }

        [MaxLength(100)]
        public string CustomerStreet { get; set; }

        [MaxLength(100)]
        public string CustomerCity { get; set; }

        [MaxLength(100)]
        public string CustomerState { get; set; }

        [MaxLength(100)]
        public string CustomerZipCode { get; set; }

        public ICollection<SaleOrderItem> SaleOrderItems { get; set; }
    }


}
