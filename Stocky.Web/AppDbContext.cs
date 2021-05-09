using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stocky.Data.Entities;
using System;

namespace Stocky
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       // Other
        public DbSet<ApplicationClaim> ApplicationClaims { get; set; }
        public DbSet<TransactionHistory> Transactions { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        //Sales
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; } 
        public DbSet<SaleOrderItem> SaleOrderItems { get; set; }

        // Purchasing
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } 
        public DbSet<PurchaseOrderItem> PurchaseOrderItems  { get; set; } 
        public DbSet<PurchaseOrderReceiveItem> PurchaseOrderReceiveItems { get; set; }  
        public DbSet<PurchaseOrderReturnItem> PurchaseOrderReturnItems { get; set; }  
        public DbSet<PurchaseOrderUnstockItem> PurchaseOrderUnstockItems { get; set; }   
        public DbSet<PurchaseOrderAttachment> PurchaseOrderAttachments { get; set; }
        public DbSet<ReceivingAddress> ReceivingAddresses { get; set; }

        // Supplier
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierAddress> SupplierAddresses { get; set; }  
        public DbSet<SupplierAddressVersion> SupplierAddressVersions { get; set; }  
        public DbSet<SupplierAttachment> SupplierAttachments  { get; set; }
        public DbSet<SupplierItem> SupplierItems { get; set; }

        #region Inventory
        // Product
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // Stock Adjustment 
        public DbSet<StockAdjustment> StockAdjustments { get; set; }
        public DbSet<StockAdjustmentVersion> StockAdjustmentVersions { get; set; }
        public DbSet<StockAdjustmentItem> StockAdjustmentItems  { get; set; }
        public DbSet<StockAdjustmentItemVersion> StockAdjustmentItemVersions { get; set; }
        public DbSet<StockAdjustmentAttachment> StockAdjustmentAttachments  { get; set; }

        // Count Sheet
        public DbSet<CountSheet> CountSheets { get; set; }
        public DbSet<CountSheetVersion> CountSheetVersions { get; set; }
        public DbSet<CountSheetAttachment> CountSheetAttachments { get; set; }
        public DbSet<CountSheetItem> CountSheetItems { get; set; }
        public DbSet<CountSheetItemVersion> CountSheetItemVersions { get; set; }

        // Stock Transfer
        public DbSet<StockTransfer> StockTransfers { get; set; }
        public DbSet<StockTransferVersion> StockTransferVersions { get; set; } 
        public DbSet<StockTransferAttachment> StockTransferAttachments { get; set; }
        public DbSet<StockTransferItem> StockTransferItems { get; set; } 
        public DbSet<StockTransferItemVersion> StockTransferItemVersions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Apply changes to identity tables
            builder.Entity<ApplicationUser>().ToTable("AppUsers");
            builder.Entity<ApplicationRole>().ToTable("AppRoles");
            builder.Entity<UserRole>().ToTable("AppUserRole");
            builder.Entity<UserLogin>().ToTable("AppUserLogins");
            builder.Entity<UserClaim>().ToTable("AppUserClaims");
            builder.Entity<UserToken>().ToTable("AppUserTokens");
            builder.Entity<RoleClaim>().ToTable("AppRoleClaims");

            // Apply database constraints using fluent api
            builder.ApplyConfiguration(new LocationMap());
            builder.ApplyConfiguration(new SupplierItemMap());
            builder.ApplyConfiguration(new StockMap()); 
            builder.ApplyConfiguration(new StockAdjustmentItemMap()); 
            builder.ApplyConfiguration(new CountSheetItemtMap()); 
            builder.ApplyConfiguration(new PurchaseOrderMap());   
            builder.ApplyConfiguration(new StockAdjustmentAttachmentMap()); 
            builder.ApplyConfiguration(new PurchaseOrderAttachmentMap()); 
            builder.ApplyConfiguration(new SupplierAttachmentMap()); 
            builder.ApplyConfiguration(new CountSheetAttachmentMap()); 
            builder.ApplyConfiguration(new StockTransferAttachmentMap()); 
        }

    }
}