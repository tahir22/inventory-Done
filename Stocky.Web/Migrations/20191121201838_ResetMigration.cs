using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Stocky.Web.Migrations
{
    public partial class ResetMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 200, nullable: true),
                    Value = table.Column<string>(maxLength: 100, nullable: true),
                    GroupName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    OnlyForOwner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    SharedKey = table.Column<string>(maxLength: 450, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 450, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Configuration = table.Column<string>(nullable: true),
                    AvatarURL = table.Column<string>(nullable: true),
                    SharedKey = table.Column<string>(maxLength: 450, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsOwner = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Size = table.Column<long>(nullable: false),
                    AttachmentURL = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    Icon = table.Column<string>(maxLength: 150, nullable: true),
                    ParentCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ColorCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    CountSheetNumber = table.Column<string>(nullable: true),
                    StartedDate = table.Column<DateTime>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    CountedBy = table.Column<string>(nullable: true),
                    SnapshotDttm = table.Column<DateTime>(nullable: true),
                    AdjustmentDttm = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Phone = table.Column<string>(maxLength: 30, nullable: true),
                    Mobile = table.Column<string>(maxLength: 30, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Street = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivingAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    AddressRemarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    AdjustmentNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsCancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTransfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    TransferNumber = table.Column<string>(nullable: true),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    SentDate = table.Column<DateTime>(nullable: true),
                    ReceivedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplierAddressVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    AddressRemarks = table.Column<string>(nullable: true),
                    VendorAddressId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAddressVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    AddressRemarks = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRole_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    InvoiceChange = table.Column<int>(nullable: false),
                    CumQty = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 500, nullable: true),
                    ApplicationUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AppUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountSheetAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CountSheetId = table.Column<Guid>(nullable: false),
                    AttachmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountSheetAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountSheetAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountSheetAttachments_CountSheets_CountSheetId",
                        column: x => x.CountSheetId,
                        principalTable: "CountSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountSheetVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    CountSheetNumber = table.Column<string>(nullable: true),
                    StartedDate = table.Column<DateTime>(nullable: false),
                    CompletedDate = table.Column<DateTime>(nullable: true),
                    CountedBy = table.Column<string>(nullable: true),
                    SnapshotDttm = table.Column<DateTime>(nullable: true),
                    AdjustmentDttm = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    CountSheetId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountSheetVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountSheetVersions_CountSheets_CountSheetId",
                        column: x => x.CountSheetId,
                        principalTable: "CountSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ManagerId = table.Column<Guid>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_Staffs_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustmentAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    StockAdjustmentId = table.Column<Guid>(nullable: false),
                    AttachmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentAttachments_StockAdjustments_StockAdjustment~",
                        column: x => x.StockAdjustmentId,
                        principalTable: "StockAdjustments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustmentVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    AdjustmentNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    IsCancelled = table.Column<bool>(nullable: false),
                    StockAdjustmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentVersions_StockAdjustments_StockAdjustmentId",
                        column: x => x.StockAdjustmentId,
                        principalTable: "StockAdjustments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockTransferAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    StockTransferId = table.Column<Guid>(nullable: false),
                    AttachmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransferAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTransferAttachments_StockTransfers_StockTransferId",
                        column: x => x.StockTransferId,
                        principalTable: "StockTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockTransferVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    TransferNumber = table.Column<string>(nullable: true),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    SentDate = table.Column<DateTime>(nullable: true),
                    ReceivedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    StockTransferId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransferVersions_StockTransfers_StockTransferId",
                        column: x => x.StockTransferId,
                        principalTable: "StockTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    OrderNumber = table.Column<string>(nullable: true),
                    SupplierOrderNumber = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    SummaryLinePermutation = table.Column<string>(nullable: true),
                    SupplierAddressRemarks = table.Column<string>(nullable: true),
                    OrderRemarks = table.Column<string>(nullable: true),
                    ReceiveRemarks = table.Column<string>(nullable: true),
                    ReturnRemarks = table.Column<string>(nullable: true),
                    UnstockRemarks = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderSubTotal = table.Column<decimal>(nullable: false),
                    OrderExtra = table.Column<decimal>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    ReturnSubTotal = table.Column<decimal>(nullable: false),
                    ReturnExtra = table.Column<decimal>(nullable: true),
                    ReturnTotal = table.Column<decimal>(nullable: false),
                    ReturnFee = table.Column<decimal>(nullable: false),
                    AncillaryExpenses = table.Column<decimal>(nullable: true),
                    ExchangeRate = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    PaymentStatus = table.Column<int>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false),
                    IsCompleted = table.Column<bool>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    RequestShipDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: true),
                    SupplierId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    AddressRemarks = table.Column<string>(nullable: true),
                    SupplierId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierAddresses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    AttachmentId = table.Column<Guid>(nullable: false),
                    SupplierId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierAttachments_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 3000, nullable: true),
                    SNO = table.Column<string>(maxLength: 500, nullable: true),
                    MinStockLevel = table.Column<int>(nullable: false),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    SellingPrice = table.Column<decimal>(nullable: false),
                    BuyingCost = table.Column<decimal>(nullable: false),
                    SellingCost = table.Column<decimal>(nullable: false),
                    Tags = table.Column<string>(maxLength: 500, nullable: true),
                    IsDiscontinued = table.Column<bool>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    Height = table.Column<float>(nullable: false),
                    Width = table.Column<float>(nullable: false),
                    Depth = table.Column<float>(nullable: false),
                    BarcodeSystem = table.Column<int>(nullable: false),
                    UPC = table.Column<string>(maxLength: 30, nullable: true),
                    SKU = table.Column<string>(maxLength: 30, nullable: true),
                    ProductPageURL = table.Column<string>(nullable: true),
                    ProductImageURL = table.Column<string>(nullable: true),
                    IsParent = table.Column<bool>(nullable: false),
                    ReorderPoint = table.Column<int>(nullable: false),
                    ReorderQuantity = table.Column<int>(nullable: false),
                    ImageId = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    BrandId = table.Column<Guid>(nullable: true),
                    ColorId = table.Column<Guid>(nullable: true),
                    SizeId = table.Column<Guid>(nullable: true),
                    DefaultLocationId = table.Column<Guid>(nullable: true),
                    LastSupplierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Locations_DefaultLocationId",
                        column: x => x.DefaultLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_LastSupplierId",
                        column: x => x.LastSupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    AttachmentId = table.Column<Guid>(nullable: false),
                    PurchaseOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderAttachments_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderAttachments_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountSheetItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Sublocation = table.Column<string>(nullable: true),
                    SnapshotQty = table.Column<decimal>(nullable: true),
                    CountedQty = table.Column<decimal>(nullable: true),
                    SnapshotSerials = table.Column<string>(nullable: true),
                    CountedSerials = table.Column<string>(nullable: true),
                    CountedQuantityUom = table.Column<string>(nullable: true),
                    CountedQuantityDisplay = table.Column<decimal>(nullable: true),
                    CountSheetId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountSheetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountSheetItems_CountSheets_CountSheetId",
                        column: x => x.CountSheetId,
                        principalTable: "CountSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountSheetItems_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountSheetItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    AttachmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttachment_Attachment_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttachment_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupplierItemCode = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: false),
                    QuantityUom = table.Column<string>(nullable: true),
                    QuantityDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    DiscountIsPercent = table.Column<bool>(nullable: true),
                    ServiceCompleted = table.Column<bool>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    PurchaseOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderReceiveItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    ReceiveDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SupplierItemCode = table.Column<string>(nullable: true),
                    Sublocation = table.Column<string>(nullable: true),
                    QuantityUom = table.Column<string>(nullable: true),
                    QuantityDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    PurchaseOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderReceiveItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderReceiveItems_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderReceiveItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderReceiveItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderReturnItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    VendorItemCode = table.Column<string>(nullable: true),
                    QuantityUom = table.Column<string>(nullable: true),
                    QuantityDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    DiscountIsPercent = table.Column<bool>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    PurchaseOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderReturnItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderReturnItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderReturnItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderUnstockItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    QuantityUom = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Sublocation = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    QuantityDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    VendorItemCode = table.Column<string>(nullable: true),
                    UnstockDate = table.Column<DateTime>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    PurchaseOrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderUnstockItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderUnstockItems_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderUnstockItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderUnstockItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    OrderReference = table.Column<string>(maxLength: 50, nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    Comments = table.Column<string>(maxLength: 2000, nullable: true),
                    CustomerId = table.Column<Guid>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: true),
                    RequiredDate = table.Column<DateTime>(nullable: true),
                    ShippedDate = table.Column<DateTime>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    StaffId = table.Column<Guid>(nullable: true),
                    CustomerName = table.Column<string>(maxLength: 150, nullable: true),
                    CustomerAddress = table.Column<string>(maxLength: 500, nullable: true),
                    CustomerPhone = table.Column<string>(maxLength: 30, nullable: true),
                    CustomerMobile = table.Column<string>(maxLength: 30, nullable: true),
                    CustomerEmail = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerStreet = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerCity = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerState = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerZipCode = table.Column<string>(maxLength: 100, nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustmentItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    QuantityBefore = table.Column<decimal>(nullable: true),
                    QuantityBeforeUom = table.Column<string>(nullable: true),
                    QuantityBeforeDisplay = table.Column<decimal>(nullable: true),
                    QuantityAfter = table.Column<decimal>(nullable: true),
                    QuantityAfterUom = table.Column<string>(nullable: true),
                    QuantityAfterDisplay = table.Column<decimal>(nullable: true),
                    Difference = table.Column<decimal>(nullable: true),
                    DifferenceUom = table.Column<string>(nullable: true),
                    DifferenceDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    StockAdjustmentId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItems_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItems_StockAdjustments_StockAdjustmentId",
                        column: x => x.StockAdjustmentId,
                        principalTable: "StockAdjustments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockTransferItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    QuantityUom = table.Column<string>(nullable: true),
                    QuantityDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    FromSublocation = table.Column<string>(nullable: true),
                    ToSublocation = table.Column<string>(nullable: true),
                    FromLocationId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    StockTransferId = table.Column<Guid>(nullable: false),
                    ToLocationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransferItems_Locations_FromLocationId",
                        column: x => x.FromLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTransferItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferItems_StockTransfers_StockTransferId",
                        column: x => x.StockTransferId,
                        principalTable: "StockTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTransferItems_Locations_ToLocationId",
                        column: x => x.ToLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    SupplierItemCode = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    SupplierId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplierItems_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountSheetItemVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Sublocation = table.Column<string>(nullable: true),
                    SnapshotQty = table.Column<decimal>(nullable: true),
                    CountedQty = table.Column<decimal>(nullable: true),
                    SnapshotSerials = table.Column<string>(nullable: true),
                    CountedSerials = table.Column<string>(nullable: true),
                    CountedQuantityUom = table.Column<string>(nullable: true),
                    CountedQuantityDisplay = table.Column<decimal>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true),
                    CountSheetId = table.Column<Guid>(nullable: true),
                    CountSheetItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountSheetItemVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountSheetItemVersions_CountSheets_CountSheetId",
                        column: x => x.CountSheetId,
                        principalTable: "CountSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountSheetItemVersions_CountSheetItems_CountSheetItemId",
                        column: x => x.CountSheetItemId,
                        principalTable: "CountSheetItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountSheetItemVersions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CountSheetItemVersions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleOrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true),
                    SaleOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleOrderItems_SaleOrders_SaleOrderId",
                        column: x => x.SaleOrderId,
                        principalTable: "SaleOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockAdjustmentItemVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    QuantityBefore = table.Column<decimal>(nullable: true),
                    QuantityBeforeUom = table.Column<string>(nullable: true),
                    QuantityBeforeDisplay = table.Column<decimal>(nullable: true),
                    QuantityAfter = table.Column<decimal>(nullable: true),
                    QuantityAfterUom = table.Column<string>(nullable: true),
                    QuantityAfterDisplay = table.Column<decimal>(nullable: true),
                    Difference = table.Column<decimal>(nullable: true),
                    DifferenceUom = table.Column<string>(nullable: true),
                    DifferenceDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    StockAdjustmentItemId = table.Column<Guid>(nullable: true),
                    StockAdjustmentId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    LocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAdjustmentItemVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItemVersions_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItemVersions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItemVersions_StockAdjustments_StockAdjustmen~",
                        column: x => x.StockAdjustmentId,
                        principalTable: "StockAdjustments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockAdjustmentItemVersions_StockAdjustmentItems_StockAdjus~",
                        column: x => x.StockAdjustmentItemId,
                        principalTable: "StockAdjustmentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockTransferItemVersions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SharedKey = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: false),
                    QuantityUom = table.Column<string>(nullable: true),
                    QuantityDisplay = table.Column<decimal>(nullable: true),
                    Serials = table.Column<string>(nullable: true),
                    FromSublocation = table.Column<string>(nullable: true),
                    ToSublocation = table.Column<string>(nullable: true),
                    FromLocationId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    StockTransferId = table.Column<Guid>(nullable: true),
                    ToLocationId = table.Column<Guid>(nullable: true),
                    StockTransferItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferItemVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransferItemVersions_Locations_FromLocationId",
                        column: x => x.FromLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferItemVersions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferItemVersions_StockTransfers_StockTransferId",
                        column: x => x.StockTransferId,
                        principalTable: "StockTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferItemVersions_StockTransferItems_StockTransferI~",
                        column: x => x.StockTransferItemId,
                        principalTable: "StockTransferItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransferItemVersions_Locations_ToLocationId",
                        column: x => x.ToLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserLogins_UserId",
                table: "AppUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRole_RoleId",
                table: "AppUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetAttachments_CountSheetId",
                table: "CountSheetAttachments",
                column: "CountSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetAttachments_AttachmentId_CountSheetId",
                table: "CountSheetAttachments",
                columns: new[] { "AttachmentId", "CountSheetId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetItems_CountSheetId",
                table: "CountSheetItems",
                column: "CountSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetItems_ProductId",
                table: "CountSheetItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetItems_LocationId_ProductId_CountSheetId",
                table: "CountSheetItems",
                columns: new[] { "LocationId", "ProductId", "CountSheetId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetItemVersions_CountSheetId",
                table: "CountSheetItemVersions",
                column: "CountSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetItemVersions_CountSheetItemId",
                table: "CountSheetItemVersions",
                column: "CountSheetItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetItemVersions_LocationId",
                table: "CountSheetItemVersions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetItemVersions_ProductId",
                table: "CountSheetItemVersions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CountSheetVersions_CountSheetId",
                table: "CountSheetVersions",
                column: "CountSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachment_AttachmentId",
                table: "ProductAttachment",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachment_ProductId",
                table: "ProductAttachment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColorId",
                table: "Products",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DefaultLocationId",
                table: "Products",
                column: "DefaultLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastSupplierId",
                table: "Products",
                column: "LastSupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SizeId",
                table: "Products",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderAttachments_PurchaseOrderId",
                table: "PurchaseOrderAttachments",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderAttachments_AttachmentId_PurchaseOrderId",
                table: "PurchaseOrderAttachments",
                columns: new[] { "AttachmentId", "PurchaseOrderId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_ProductId",
                table: "PurchaseOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchaseOrderId",
                table: "PurchaseOrderItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderReceiveItems_LocationId",
                table: "PurchaseOrderReceiveItems",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderReceiveItems_ProductId",
                table: "PurchaseOrderReceiveItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderReceiveItems_PurchaseOrderId",
                table: "PurchaseOrderReceiveItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderReturnItems_ProductId",
                table: "PurchaseOrderReturnItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderReturnItems_PurchaseOrderId",
                table: "PurchaseOrderReturnItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_LocationId",
                table: "PurchaseOrders",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_OrderNumber",
                table: "PurchaseOrders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderUnstockItems_LocationId",
                table: "PurchaseOrderUnstockItems",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderUnstockItems_ProductId",
                table: "PurchaseOrderUnstockItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderUnstockItems_PurchaseOrderId",
                table: "PurchaseOrderUnstockItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderItems_ProductId",
                table: "SaleOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderItems_SaleOrderId",
                table: "SaleOrderItems",
                column: "SaleOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_CustomerId",
                table: "SaleOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_LocationId",
                table: "SaleOrders",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_ProductId",
                table: "SaleOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_StaffId",
                table: "SaleOrders",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_LocationId",
                table: "Staffs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ManagerId",
                table: "Staffs",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentAttachments_StockAdjustmentId",
                table: "StockAdjustmentAttachments",
                column: "StockAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentAttachments_AttachmentId_StockAdjustmentId",
                table: "StockAdjustmentAttachments",
                columns: new[] { "AttachmentId", "StockAdjustmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItems_ProductId",
                table: "StockAdjustmentItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItems_StockAdjustmentId",
                table: "StockAdjustmentItems",
                column: "StockAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItems_LocationId_ProductId_StockAdjustmentId",
                table: "StockAdjustmentItems",
                columns: new[] { "LocationId", "ProductId", "StockAdjustmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItemVersions_LocationId",
                table: "StockAdjustmentItemVersions",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItemVersions_ProductId",
                table: "StockAdjustmentItemVersions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItemVersions_StockAdjustmentId",
                table: "StockAdjustmentItemVersions",
                column: "StockAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentItemVersions_StockAdjustmentItemId",
                table: "StockAdjustmentItemVersions",
                column: "StockAdjustmentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAdjustmentVersions_StockAdjustmentId",
                table: "StockAdjustmentVersions",
                column: "StockAdjustmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_LocationId",
                table: "Stocks",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId_LocationId",
                table: "Stocks",
                columns: new[] { "ProductId", "LocationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferAttachments_StockTransferId",
                table: "StockTransferAttachments",
                column: "StockTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferAttachments_AttachmentId_StockTransferId",
                table: "StockTransferAttachments",
                columns: new[] { "AttachmentId", "StockTransferId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItems_FromLocationId",
                table: "StockTransferItems",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItems_ProductId",
                table: "StockTransferItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItems_StockTransferId",
                table: "StockTransferItems",
                column: "StockTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItems_ToLocationId",
                table: "StockTransferItems",
                column: "ToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItemVersions_FromLocationId",
                table: "StockTransferItemVersions",
                column: "FromLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItemVersions_ProductId",
                table: "StockTransferItemVersions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItemVersions_StockTransferId",
                table: "StockTransferItemVersions",
                column: "StockTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItemVersions_StockTransferItemId",
                table: "StockTransferItemVersions",
                column: "StockTransferItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItemVersions_ToLocationId",
                table: "StockTransferItemVersions",
                column: "ToLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferVersions_StockTransferId",
                table: "StockTransferVersions",
                column: "StockTransferId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAddresses_SupplierId",
                table: "SupplierAddresses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAttachments_SupplierId",
                table: "SupplierAttachments",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAttachments_AttachmentId_SupplierId",
                table: "SupplierAttachments",
                columns: new[] { "AttachmentId", "SupplierId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItems_SupplierId",
                table: "SupplierItems",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierItems_ProductId_SupplierId",
                table: "SupplierItems",
                columns: new[] { "ProductId", "SupplierId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ApplicationUserId",
                table: "Transactions",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppClaims");

            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRole");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "CountSheetAttachments");

            migrationBuilder.DropTable(
                name: "CountSheetItemVersions");

            migrationBuilder.DropTable(
                name: "CountSheetVersions");

            migrationBuilder.DropTable(
                name: "ProductAttachment");

            migrationBuilder.DropTable(
                name: "PurchaseOrderAttachments");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrderReceiveItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrderReturnItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrderUnstockItems");

            migrationBuilder.DropTable(
                name: "ReceivingAddresses");

            migrationBuilder.DropTable(
                name: "SaleOrderItems");

            migrationBuilder.DropTable(
                name: "StockAdjustmentAttachments");

            migrationBuilder.DropTable(
                name: "StockAdjustmentItemVersions");

            migrationBuilder.DropTable(
                name: "StockAdjustmentVersions");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "StockTransferAttachments");

            migrationBuilder.DropTable(
                name: "StockTransferItemVersions");

            migrationBuilder.DropTable(
                name: "StockTransferVersions");

            migrationBuilder.DropTable(
                name: "SupplierAddresses");

            migrationBuilder.DropTable(
                name: "SupplierAddressVersions");

            migrationBuilder.DropTable(
                name: "SupplierAttachments");

            migrationBuilder.DropTable(
                name: "SupplierItems");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "CountSheetItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropTable(
                name: "StockAdjustmentItems");

            migrationBuilder.DropTable(
                name: "StockTransferItems");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "CountSheets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "StockAdjustments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StockTransfers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
