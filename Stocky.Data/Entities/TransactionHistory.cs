using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("Transactions")]
    public class TransactionHistory : DomainBaseEntity
    {
        // TransacId, Type, ProductId, Quantity, InvoiceChange, CumQty, UserId, Remarks							
        [StringLength(50)]
        public string Type { get; set; }

        public int Quantity { get; set; }
        public int InvoiceChange { get; set; } // Invoice change (RECEIVED or ISSUES items)
        public int CumQty { get; set; } // Quantity after invoice change

        [StringLength(500)]
        public string Remarks { get; set; }

        [ForeignKey("User")]
        public Guid? ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
