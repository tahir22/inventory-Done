using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Data.Entities
{
    // LocationMap
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            // builder.HasData(DefaultData);
        }
    }

    // SupplierItemMap
    public class SupplierItemMap : IEntityTypeConfiguration<SupplierItem>
    {
        public void Configure(EntityTypeBuilder<SupplierItem> builder)
        {
            //builder.HasKey(ps => new { ps.ProductId, ps.SupplierId }); 
            builder.HasIndex(ps => new { ps.ProductId, ps.SupplierId }).IsUnique();
        }
    }

    // StockMap
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasIndex(ps => new { ps.ProductId, ps.LocationId }).IsUnique();
        }
    }

    // CountSheetItemtMap
    public class CountSheetItemtMap : IEntityTypeConfiguration<CountSheetItem>
    {
        public void Configure(EntityTypeBuilder<CountSheetItem> builder)
        {
            builder.HasIndex(x => new { x.LocationId, x.ProductId, x.CountSheetId }).IsUnique();
        }
    }

    // PurchaseOrderMap
    public class PurchaseOrderMap : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.HasIndex(x => new { x.OrderNumber }).IsUnique(); 
        }
    }

    // StockAdjustmentItemMap
    public class StockAdjustmentItemMap : IEntityTypeConfiguration<StockAdjustmentItem>
    {
        public void Configure(EntityTypeBuilder<StockAdjustmentItem> builder)
        {
            builder.HasIndex(x => new { x.LocationId, x.ProductId, x.StockAdjustmentId }).IsUnique();
        }
    }

    // ==================== Attachment's Map ====================
    // StockAdjustmentAttachmentMap
    public class StockAdjustmentAttachmentMap : IEntityTypeConfiguration<StockAdjustmentAttachment>
    {
        public void Configure(EntityTypeBuilder<StockAdjustmentAttachment> builder)
        {
            builder.HasIndex(x => new { x.AttachmentId, x.StockAdjustmentId }).IsUnique();
        }
    }

    // PurchaseOrderAttachmentMap
    public class PurchaseOrderAttachmentMap : IEntityTypeConfiguration<PurchaseOrderAttachment>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderAttachment> builder)
        {
            builder.HasIndex(x => new { x.AttachmentId, x.PurchaseOrderId }).IsUnique();
        }
    }

    // SupplierAttachmentMap
    public class SupplierAttachmentMap : IEntityTypeConfiguration<SupplierAttachment>
    {
        public void Configure(EntityTypeBuilder<SupplierAttachment> builder)
        {
            builder.HasIndex(x => new { x.AttachmentId, x.SupplierId }).IsUnique();
        }
    }

    // CountSheetAttachmentMap
    public class CountSheetAttachmentMap : IEntityTypeConfiguration<CountSheetAttachment>
    {
        public void Configure(EntityTypeBuilder<CountSheetAttachment> builder)
        {
            builder.HasIndex(x => new { x.AttachmentId, x.CountSheetId }).IsUnique();
        }
    }

    // StockTransferAttachmentMap
    public class StockTransferAttachmentMap : IEntityTypeConfiguration<StockTransferAttachment>
    {
        public void Configure(EntityTypeBuilder<StockTransferAttachment> builder)
        {
            builder.HasIndex(x => new { x.AttachmentId, x.StockTransferId }).IsUnique();
        }
    }

}
