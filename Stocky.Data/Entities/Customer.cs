using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stocky.Data.Entities
{
    [Table("Customers")]
    public class Customer : DomainBaseEntity
    {
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Street { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [MaxLength(100)]
        public string ZipCode { get; set; }

        public IList<SaleOrder> SaleOrders { get; set; }
    }

}
