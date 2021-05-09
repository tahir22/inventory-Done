using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Stocky.Data.Entities
{
    [Table("Products")]
    public class Product : DomainBaseEntity
    {
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(3000)]
        public string Description { get; set; }

        [StringLength(500)]
        public string SNO { get; set; } // Serial Numbers // -- Serial Numbers separated with comma

        // Minimum Stock Count, system will show alerts when count below this. 
        public int MinStockLevel { get; set; }

        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        
        public decimal BuyingCost { get; set; }
        public decimal SellingCost { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }
        public bool IsDiscontinued { get; set; }

        public float Weight { get; set; } // KG
        public float Height { get; set; } // CM
        public float Width { get; set; } // CM
        public float Depth { get; set; } // CM

        public BarcodeSystem BarcodeSystem { get; set; } // enums

        [StringLength(30)]
        public string UPC { get; set; } // Universal Product Code, for barcode

        [StringLength(30)]
        public string SKU { get; set; } // Stock Keeping Unit

        // URL of a product's page. e.g if product is available on ebay or other sites. 
        public string ProductPageURL { get; set; }

        // Image of the of the product.
        public string ProductImageURL { get; set; }

        public bool IsParent { get; set; }
        public int ReorderPoint { get; set; }
        public int ReorderQuantity { get; set; }

        //// IssueInventoryLocation, ReceiveInventoryLocation,  
        //SoUomName
        //SoUomRatioStd
        //SoUomRatio
        //PoUomName
        //PoUomRatioStd
        //PoUomRatio

        [ForeignKey("Image")]
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        [ForeignKey("Parent")]
        public Guid? ParentId { get; set; }
        public Product Parent { get; set; }

        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("Brand")]
        public Guid? BrandId { get; set; }
        public Brand Brand { get; set; }

        [ForeignKey("Color")]
        public Guid? ColorId { get; set; }
        public Color Color { get; set; }

        [ForeignKey("Size")]
        public Guid? SizeId { get; set; }
        public Size Size { get; set; }

        [ForeignKey("DefaultLocation")]
        public Guid? DefaultLocationId { get; set; }
        public Location DefaultLocation { get; set; }

        [ForeignKey("LastSupplier")]
        public Guid? LastSupplierId { get; set; }
        public Supplier LastSupplier { get; set; }
          
        public virtual ICollection<SaleOrderItem> SaleOrderItems { get; set; }
        public virtual ICollection<SaleOrder> SaleOrders { get; set; }
        public virtual ICollection<Product> Children { get; set; } 
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<SupplierItem> SupplierItems { get; set; }
        public virtual ICollection<ProductAttachment> ProductAttachments  { get; set; }

        //public virtual ICollection<StockAdjustmentItem> StockAdjustmentItems { get; set; }

        [NotMapped]
        public int UnitsInStock { get; set; } // copy inventory initial data from this

        [NotMapped]
        public IEnumerable<Stock> ProductStocks { get; set; } 
    }
}
