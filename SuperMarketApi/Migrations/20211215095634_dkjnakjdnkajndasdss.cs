using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class dkjnakjdnkajndasdss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AccountType",
            //    columns: table => new
            //    {
            //        AccountTypeCd = table.Column<string>(nullable: false),
            //        Description = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AccountType", x => x.AccountTypeCd);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Companies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Address = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        State = table.Column<string>(nullable: true),
            //        Country = table.Column<string>(nullable: true),
            //        PostalCode = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Companies", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DropDownGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DropDownGroups", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "EnumVal",
            //    columns: table => new
            //    {
            //        Code = table.Column<string>(nullable: false),
            //        Description = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_EnumVal", x => x.Code);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OfferTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OfferTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Operators",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        OperType = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Operators", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PaymentTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PaymentTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Printers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Type = table.Column<string>(nullable: true),
            //        Size = table.Column<string>(nullable: true),
            //        IPAddress = table.Column<string>(nullable: true),
            //        PortNumber = table.Column<int>(nullable: false),
            //        NoOfCharacters = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Printers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Registrations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        RestaurentName = table.Column<string>(nullable: true),
            //        EmailId = table.Column<string>(nullable: true),
            //        Password = table.Column<string>(nullable: true),
            //        ConfirmPassword = table.Column<string>(nullable: true),
            //        PhoneNo = table.Column<string>(nullable: true),
            //        Provider = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Registrations", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Roles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Roles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TransTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TransTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Units",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Units", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UPOptionGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ref_id = table.Column<string>(nullable: true),
            //        title = table.Column<string>(nullable: true),
            //        min_selectable = table.Column<int>(nullable: false),
            //        max_selectable = table.Column<int>(nullable: false),
            //        active = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UPOptionGroups", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UPOptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ref_id = table.Column<string>(nullable: true),
            //        title = table.Column<string>(nullable: true),
            //        description = table.Column<string>(nullable: true),
            //        food_type = table.Column<int>(nullable: false),
            //        sold_at_store = table.Column<bool>(nullable: false),
            //        available = table.Column<bool>(nullable: false),
            //        price = table.Column<double>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UPOptions", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VariableTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VariableTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "WebhookResponses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        RefId = table.Column<string>(nullable: true),
            //        StatusCode = table.Column<int>(nullable: false),
            //        message = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_WebhookResponses", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Accounts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        Password = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        PhoneNo = table.Column<string>(maxLength: 50, nullable: false),
            //        UPUsername = table.Column<string>(nullable: true),
            //        UPAPIKey = table.Column<string>(nullable: true),
            //        SatUname = table.Column<string>(nullable: true),
            //        SatPass = table.Column<string>(nullable: true),
            //        FCM_Token = table.Column<string>(nullable: true),
            //        bizid = table.Column<string>(nullable: true),
            //        IsConfirmed = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Accounts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Accounts_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AddonGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AddonGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AddonGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Brands",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Brands", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Brands_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Categories",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        FreeQtyPercentage = table.Column<int>(nullable: true),
            //        MinimumQty = table.Column<int>(nullable: true),
            //        IsUPCategory = table.Column<bool>(nullable: false),
            //        IsSynced = table.Column<bool>(nullable: false),
            //        isactive = table.Column<bool>(nullable: false),
            //        SortOrder = table.Column<int>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        ParentCategoryId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Categories", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Categories_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Categories_Categories_ParentCategoryId",
            //            column: x => x.ParentCategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Contacts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        IsActive = table.Column<bool>(nullable: false),
            //        ContactTypeId = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        FirstName = table.Column<string>(nullable: true),
            //        Surname = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        PhoneNo = table.Column<string>(nullable: true),
            //        AlternatePhoneNo = table.Column<string>(nullable: true),
            //        Address = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        State = table.Column<string>(nullable: true),
            //        Zip = table.Column<string>(nullable: true),
            //        Notes = table.Column<string>(nullable: true),
            //        StartDate = table.Column<DateTime>(nullable: true),
            //        AadharId = table.Column<string>(nullable: true),
            //        TaxIdentNumber = table.Column<string>(nullable: true),
            //        IdProof = table.Column<byte[]>(nullable: true),
            //        AltIdProof = table.Column<byte[]>(nullable: true),
            //        ParentContactId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contacts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Contacts_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Contacts_Contacts_ParentContactId",
            //            column: x => x.ParentContactId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DiscountRules",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CouponCode = table.Column<string>(nullable: true),
            //        DiscountType = table.Column<int>(nullable: false),
            //        DiscountValue = table.Column<double>(nullable: false),
            //        MiniOrderValue = table.Column<double>(nullable: false),
            //        MaxDiscountAmount = table.Column<double>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        StartDate = table.Column<DateTime>(nullable: true),
            //        EndDate = table.Column<DateTime>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DiscountRules", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DiscountRules_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "KOTGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        Printer = table.Column<string>(nullable: true),
            //        IsEditable = table.Column<bool>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_KOTGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_KOTGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Offers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        EffectiveDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        ExpiryDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        UpdateDateTime = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Offers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Offers_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OptionGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        OptionGroupType = table.Column<int>(nullable: false),
            //        MinimumSelectable = table.Column<int>(nullable: false),
            //        MaximumSelectable = table.Column<int>(nullable: false),
            //        SortOrder = table.Column<int>(nullable: false),
            //        IsSynced = table.Column<bool>(nullable: false),
            //        isactive = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OptionGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OptionGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Preferences",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        KOTGenerate = table.Column<bool>(nullable: false),
            //        EnforceCustomerNo = table.Column<bool>(nullable: false),
            //        QuickOrder = table.Column<bool>(nullable: false),
            //        FreeQuantity = table.Column<bool>(nullable: false),
            //        ShowUpcategory = table.Column<bool>(nullable: false),
            //        ShowTaxonBill = table.Column<bool>(nullable: false),
            //        AdminOnlyCancel = table.Column<bool>(nullable: false),
            //        DineIn = table.Column<bool>(nullable: false),
            //        TakeAway = table.Column<bool>(nullable: false),
            //        AdvanceOrder = table.Column<bool>(nullable: false),
            //        OnlineOrder = table.Column<bool>(nullable: false),
            //        Delivery = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        PriceType = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Preferences", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Preferences_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Stores",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        ParentStoreId = table.Column<int>(nullable: true),
            //        IsSalesStore = table.Column<bool>(nullable: false),
            //        Address = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        PostalCode = table.Column<string>(nullable: true),
            //        Country = table.Column<string>(nullable: true),
            //        ContactNo = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        GSTno = table.Column<string>(nullable: true),
            //        receiptprinter = table.Column<string>(nullable: true),
            //        kotprinter = table.Column<string>(nullable: true),
            //        isactive = table.Column<bool>(nullable: false),
            //        FoodPrepTime = table.Column<int>(nullable: false),
            //        AutoAcceptTime = table.Column<int>(nullable: false),
            //        OpeningTime = table.Column<TimeSpan>(nullable: false),
            //        ClosingTime = table.Column<TimeSpan>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Stores", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Stores_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Stores_Stores_ParentStoreId",
            //            column: x => x.ParentStoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TaxGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Tax1 = table.Column<double>(nullable: false),
            //        Tax2 = table.Column<double>(nullable: false),
            //        Tax3 = table.Column<double>(nullable: false),
            //        IsInclusive = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TaxGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TaxGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "VariantGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        SortOrder = table.Column<int>(nullable: false),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_VariantGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_VariantGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DropDowns",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        DropDownGroupId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DropDowns", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DropDowns_DropDownGroups_DropDownGroupId",
            //            column: x => x.DropDownGroupId,
            //            principalTable: "DropDownGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Isdefault = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        RoleId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserRoles", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserRoles_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserRoles_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cnditions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        VariableTypeId = table.Column<int>(nullable: false),
            //        ParentCnditionId = table.Column<int>(nullable: false),
            //        ValueId = table.Column<int>(nullable: false),
            //        OperatorId = table.Column<int>(nullable: false),
            //        JoinOperatorId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cnditions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Cnditions_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Cnditions_Operators_JoinOperatorId",
            //            column: x => x.JoinOperatorId,
            //            principalTable: "Operators",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Cnditions_Operators_OperatorId",
            //            column: x => x.OperatorId,
            //            principalTable: "Operators",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Cnditions_Cnditions_ParentCnditionId",
            //            column: x => x.ParentCnditionId,
            //            principalTable: "Cnditions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Cnditions_VariableTypes_VariableTypeId",
            //            column: x => x.VariableTypeId,
            //            principalTable: "VariableTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Results",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        VariableTypeId = table.Column<int>(nullable: false),
            //        OfferTypeId = table.Column<int>(nullable: false),
            //        value = table.Column<double>(nullable: false),
            //        OperatorId = table.Column<int>(nullable: false),
            //        OperatorValue = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Results", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Results_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Results_OfferTypes_OfferTypeId",
            //            column: x => x.OfferTypeId,
            //            principalTable: "OfferTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Results_Operators_OperatorId",
            //            column: x => x.OperatorId,
            //            principalTable: "Operators",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Results_VariableTypes_VariableTypeId",
            //            column: x => x.VariableTypeId,
            //            principalTable: "VariableTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UrbanPiperKeys",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        UserName = table.Column<string>(nullable: true),
            //        ApiKey = table.Column<string>(nullable: true),
            //        Zomato = table.Column<bool>(nullable: false),
            //        Swiggy = table.Column<bool>(nullable: false),
            //        FoodPanda = table.Column<bool>(nullable: false),
            //        UberEats = table.Column<bool>(nullable: false),
            //        UrbanPiper = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        AccountId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UrbanPiperKeys", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UrbanPiperKeys_Accounts_AccountId",
            //            column: x => x.AccountId,
            //            principalTable: "Accounts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UrbanPiperKeys_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Pin = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        AccountId = table.Column<int>(nullable: false),
            //        RoleId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Users_Accounts_AccountId",
            //            column: x => x.AccountId,
            //            principalTable: "Accounts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Users_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Users_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BankAccounts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        AccountTypeCd = table.Column<string>(nullable: true),
            //        AccountNo = table.Column<string>(maxLength: 50, nullable: true),
            //        BankName = table.Column<string>(nullable: false),
            //        AccountHolder = table.Column<string>(nullable: true),
            //        CardNumber = table.Column<string>(nullable: true),
            //        CreditLimit = table.Column<double>(nullable: true),
            //        ExpiryDate = table.Column<DateTime>(nullable: true),
            //        Balance = table.Column<double>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        BranchCode = table.Column<string>(nullable: true),
            //        AllowNegative = table.Column<bool>(nullable: false),
            //        IsActive = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BankAccounts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_BankAccounts_AccountType_AccountTypeCd",
            //            column: x => x.AccountTypeCd,
            //            principalTable: "AccountType",
            //            principalColumn: "AccountTypeCd",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_BankAccounts_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BankAccounts_Contacts_Id",
            //            column: x => x.Id,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CtTypes",
            //    columns: table => new
            //    {
            //        CtTypeId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        CreditPeriod = table.Column<int>(nullable: false),
            //        IsAccount = table.Column<bool>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CtTypes", x => x.CtTypeId);
            //        table.ForeignKey(
            //            name: "FK_CtTypes_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LiabilityTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        IsVehicle = table.Column<bool>(nullable: false),
            //        IsOnlinePayment = table.Column<bool>(nullable: false),
            //        IsActive = table.Column<bool>(nullable: false),
            //        IsSpecial = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LiabilityTypes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LiabilityTypes_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_LiabilityTypes_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItemTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderItemTypes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OrderItemTypes_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderItemTypes_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TransModes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        IsIn = table.Column<bool>(nullable: false),
            //        IsOut = table.Column<bool>(nullable: false),
            //        IsStoreTrx = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TransModes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_TransModes_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OfferRules",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        OfferId = table.Column<int>(nullable: false),
            //        RuleId = table.Column<int>(nullable: false),
            //        Type = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OfferRules", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OfferRules_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OfferRules_Offers_OfferId",
            //            column: x => x.OfferId,
            //            principalTable: "Offers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryOptionGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        OptionGroupId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        UPPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryOptionGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryOptionGroups_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryOptionGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryOptionGroups_OptionGroups_OptionGroupId",
            //            column: x => x.OptionGroupId,
            //            principalTable: "OptionGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Options",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        SortOrder = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: false),
            //        DeliveryPrice = table.Column<double>(nullable: false),
            //        UPPrice = table.Column<double>(nullable: false),
            //        IsSynced = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        OptionGroupId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Options", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Options_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Options_OptionGroups_OptionGroupId",
            //            column: x => x.OptionGroupId,
            //            principalTable: "OptionGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        PhoneNo = table.Column<string>(nullable: true),
            //        Address = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        PostalCode = table.Column<int>(nullable: true),
            //        Password = table.Column<string>(nullable: true),
            //        OTP = table.Column<string>(nullable: true),
            //        RemainingPoints = table.Column<int>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        LastRedeemDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        TotalPoints = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Customers_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Customers_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DiningAreas",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DiningAreas", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DiningAreas_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DiningAreas_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "KOTGroupPrinters",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Printer = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        KOTGroupId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_KOTGroupPrinters", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_KOTGroupPrinters_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_KOTGroupPrinters_KOTGroups_KOTGroupId",
            //            column: x => x.KOTGroupId,
            //            principalTable: "KOTGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_KOTGroupPrinters_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PlannedTrans",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ContactId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: true),
            //        BillId = table.Column<int>(nullable: true),
            //        InVoiceNum = table.Column<string>(nullable: true),
            //        BillDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        Amount = table.Column<double>(nullable: false),
            //        Comments = table.Column<string>(nullable: true),
            //        PlannedDateTime = table.Column<DateTime>(nullable: true),
            //        PlannedDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        ClosedDate = table.Column<DateTime>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        StatusCode = table.Column<string>(nullable: true),
            //        Image1 = table.Column<byte[]>(nullable: true),
            //        Image2 = table.Column<byte[]>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PlannedTrans", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PlannedTrans_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PlannedTrans_Contacts_ContactId",
            //            column: x => x.ContactId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_PlannedTrans_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PlannedTrans_EnumVal_StatusCode",
            //            column: x => x.StatusCode,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PlannedTrans_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StorePreferences",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        KOTGenerate = table.Column<bool>(nullable: false),
            //        EnforceCustomerNo = table.Column<bool>(nullable: false),
            //        QuickOrder = table.Column<bool>(nullable: false),
            //        FreeQuantity = table.Column<bool>(nullable: false),
            //        ShowUpcategory = table.Column<bool>(nullable: false),
            //        ShowTaxonBill = table.Column<bool>(nullable: false),
            //        AdminOnlyCancel = table.Column<bool>(nullable: false),
            //        DineIn = table.Column<bool>(nullable: false),
            //        TakeAway = table.Column<bool>(nullable: false),
            //        AdvanceOrder = table.Column<bool>(nullable: false),
            //        OnlineOrder = table.Column<bool>(nullable: false),
            //        Delivery = table.Column<bool>(nullable: false),
            //        customeraddressinbill = table.Column<bool>(nullable: false),
            //        showchildcategory = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StorePreferences", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_StorePreferences_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StorePreferences_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UPLogs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Action = table.Column<string>(nullable: true),
            //        Json = table.Column<string>(nullable: true),
            //        ReferenceId = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        LogDateTime = table.Column<DateTime>(nullable: false),
            //        BrandId = table.Column<int>(nullable: true),
            //        StoreId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UPLogs", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UPLogs_Brands_BrandId",
            //            column: x => x.BrandId,
            //            principalTable: "Brands",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_UPLogs_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UPLogs_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UrbanPiperStores",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        LocationName = table.Column<string>(nullable: true),
            //        UPId = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        Zomato = table.Column<bool>(nullable: false),
            //        IsZomato = table.Column<bool>(nullable: false),
            //        Swiggy = table.Column<bool>(nullable: false),
            //        IsSwiggy = table.Column<bool>(nullable: false),
            //        UberEats = table.Column<bool>(nullable: false),
            //        FoodPanda = table.Column<bool>(nullable: false),
            //        IsUrbanPiper = table.Column<bool>(nullable: false),
            //        UrbanPiper = table.Column<bool>(nullable: false),
            //        Dunzo = table.Column<bool>(nullable: false),
            //        IsDunzo = table.Column<bool>(nullable: false),
            //        Amazon = table.Column<bool>(nullable: false),
            //        IsAmazon = table.Column<bool>(nullable: false),
            //        BrandId = table.Column<int>(nullable: true),
            //        FoodPrepTime = table.Column<TimeSpan>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UrbanPiperStores", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UrbanPiperStores_Brands_BrandId",
            //            column: x => x.BrandId,
            //            principalTable: "Brands",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_UrbanPiperStores_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UrbanPiperStores_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Vendors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(nullable: true),
            //        Email = table.Column<string>(nullable: true),
            //        PhoneNo = table.Column<string>(nullable: true),
            //        Address = table.Column<string>(nullable: true),
            //        City = table.Column<string>(nullable: true),
            //        PostalCode = table.Column<int>(nullable: true),
            //        Password = table.Column<string>(nullable: true),
            //        OTP = table.Column<string>(nullable: true),
            //        RemainingPoints = table.Column<int>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        LastRedeemDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        TotalPoints = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: true),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        BusinessName = table.Column<string>(maxLength: 50, nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        CreditPeriod = table.Column<int>(nullable: true),
            //        IsPlanned = table.Column<bool>(nullable: false),
            //        PaymentStoreId = table.Column<int>(nullable: true),
            //        DelivPeriod = table.Column<int>(nullable: false),
            //        DelivTimeHrs = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Vendors", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Vendors_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Vendors_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Vendors_Contacts_Id",
            //            column: x => x.Id,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Vendors_Stores_PaymentStoreId",
            //            column: x => x.PaymentStoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Vendors_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AdditionalCharges",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        ChargeType = table.Column<int>(nullable: false),
            //        ChargeValue = table.Column<double>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        TaxGroupId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AdditionalCharges", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AdditionalCharges_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AdditionalCharges_TaxGroups_TaxGroupId",
            //            column: x => x.TaxGroupId,
            //            principalTable: "TaxGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        UnitId = table.Column<int>(nullable: false),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: false),
            //        DeliveryPrice = table.Column<double>(nullable: false),
            //        UPPrice = table.Column<double>(nullable: false),
            //        ImgUrl = table.Column<string>(nullable: true),
            //        ProductCode = table.Column<string>(nullable: true),
            //        BarCode = table.Column<string>(nullable: true),
            //        isactive = table.Column<bool>(nullable: false),
            //        SortOrder = table.Column<int>(nullable: true),
            //        Recomended = table.Column<bool>(nullable: false),
            //        minquantity = table.Column<int>(nullable: true),
            //        minblock = table.Column<int>(nullable: true),
            //        brand = table.Column<string>(nullable: true),
            //        TaxGroupId = table.Column<int>(nullable: false),
            //        KOTGroupId = table.Column<int>(nullable: true),
            //        Image = table.Column<byte[]>(nullable: true),
            //        ProductTypeId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        Factor = table.Column<double>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Products_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Products_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Products_KOTGroups_KOTGroupId",
            //            column: x => x.KOTGroupId,
            //            principalTable: "KOTGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Products_ProductTypes_ProductTypeId",
            //            column: x => x.ProductTypeId,
            //            principalTable: "ProductTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Products_TaxGroups_TaxGroupId",
            //            column: x => x.TaxGroupId,
            //            principalTable: "TaxGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Products_Units_UnitId",
            //            column: x => x.UnitId,
            //            principalTable: "Units",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryVariantGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        VariantGroupId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryVariantGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryVariantGroups_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryVariantGroups_VariantGroups_VariantGroupId",
            //            column: x => x.VariantGroupId,
            //            principalTable: "VariantGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ScreenRules",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        UserId = table.Column<int>(nullable: true),
            //        RoleId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: true),
            //        Rules = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ScreenRules", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ScreenRules_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_ScreenRules_Roles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "Roles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_ScreenRules_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ShiftSummaries",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        OpeningBalance = table.Column<double>(nullable: false),
            //        ClosingBalance = table.Column<double>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        ShiftStartTime = table.Column<DateTime>(nullable: false),
            //        ShiftEndTime = table.Column<DateTime>(nullable: false),
            //        SalesDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        UserId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ShiftSummaries", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ShiftSummaries_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ShiftSummaries_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ShiftSummaries_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UserStores",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        UserId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UserStores", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserStores_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UserStores_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "MaintBillTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        LiabilityTypeId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        IsActive = table.Column<bool>(nullable: false),
            //        IsVerify = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MaintBillTypes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_MaintBillTypes_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_MaintBillTypes_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_MaintBillTypes_LiabilityTypes_LiabilityTypeId",
            //            column: x => x.LiabilityTypeId,
            //            principalTable: "LiabilityTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StoreOptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        OptionId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: true),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        UPPrice = table.Column<double>(nullable: true),
            //        IsActive = table.Column<bool>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StoreOptions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_StoreOptions_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreOptions_Options_OptionId",
            //            column: x => x.OptionId,
            //            principalTable: "Options",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreOptions_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CustomerAddress",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Address = table.Column<string>(nullable: true),
            //        Contact = table.Column<string>(nullable: true),
            //        iscurrentaddress = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        CustomerId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomerAddress", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CustomerAddress_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CustomerAddress_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CustomerOffers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CustomerId = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        OfferId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CustomerOffers", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CustomerOffers_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CustomerOffers_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CustomerOffers_Offers_OfferId",
            //            column: x => x.OfferId,
            //            principalTable: "Offers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DiningTables",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Description = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        DiningAreaId = table.Column<int>(nullable: false),
            //        TableStatusId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DiningTables", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DiningTables_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DiningTables_DiningAreas_DiningAreaId",
            //            column: x => x.DiningAreaId,
            //            principalTable: "DiningAreas",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_DiningTables_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Liabilities",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Count = table.Column<int>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        LiabilityTypeId = table.Column<int>(nullable: false),
            //        ContactId = table.Column<int>(nullable: true),
            //        VendorId = table.Column<int>(nullable: true),
            //        StoreId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        IsActive = table.Column<bool>(nullable: false),
            //        IsOnlinePayment = table.Column<bool>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Liabilities", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Liabilities_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Liabilities_Contacts_ContactId",
            //            column: x => x.ContactId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Liabilities_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Liabilities_LiabilityTypes_LiabilityTypeId",
            //            column: x => x.LiabilityTypeId,
            //            principalTable: "LiabilityTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Liabilities_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Liabilities_Vendors_VendorId",
            //            column: x => x.VendorId,
            //            principalTable: "Vendors",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Addons",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductId = table.Column<int>(nullable: false),
            //        AddonGroupId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Addons", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Addons_AddonGroups_AddonGroupId",
            //            column: x => x.AddonGroupId,
            //            principalTable: "AddonGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Addons_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Addons_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AutoOrder",
            //    columns: table => new
            //    {
            //        AutoOrderId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        SupplierId = table.Column<int>(nullable: true),
            //        OrderStoreId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: true),
            //        CategoryId = table.Column<int>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        IsIgnorePendOrd = table.Column<bool>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AutoOrder", x => x.AutoOrderId);
            //        table.ForeignKey(
            //            name: "FK_AutoOrder_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AutoOrder_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AutoOrder_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AutoOrder_Stores_OrderStoreId",
            //            column: x => x.OrderStoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AutoOrder_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_AutoOrder_Contacts_SupplierId",
            //            column: x => x.SupplierId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Barcodes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        BarCode = table.Column<string>(nullable: true),
            //        ProductId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Barcodes", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Barcodes_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductAddonGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        AddonGroupId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductAddonGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductAddonGroups_AddonGroups_AddonGroupId",
            //            column: x => x.AddonGroupId,
            //            principalTable: "AddonGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductAddonGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductAddonGroups_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductOptionGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        OptionGroupId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductOptionGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductOptionGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductOptionGroups_OptionGroups_OptionGroupId",
            //            column: x => x.OptionGroupId,
            //            principalTable: "OptionGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductOptionGroups_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductOptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductId = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        OptionId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        UPPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductOptions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductOptions_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductOptions_Options_OptionId",
            //            column: x => x.OptionId,
            //            principalTable: "Options",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductOptions_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductVariantGroups",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        VariantGroupId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductVariantGroups", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductVariantGroups_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductVariantGroups_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductVariantGroups_VariantGroups_VariantGroupId",
            //            column: x => x.VariantGroupId,
            //            principalTable: "VariantGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StockContainer",
            //    columns: table => new
            //    {
            //        StockContainerId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        StoreId = table.Column<int>(nullable: true),
            //        StockContainerName = table.Column<string>(nullable: true),
            //        ContainerWight = table.Column<double>(nullable: false),
            //        IsActive = table.Column<bool>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        IsCompanyLevel = table.Column<bool>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StockContainer", x => x.StockContainerId);
            //        table.ForeignKey(
            //            name: "FK_StockContainer_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StockContainer_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_StockContainer_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_StockContainer_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StoreProducts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        UPPrice = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: false),
            //        DeliveryPrice = table.Column<double>(nullable: false),
            //        IsDineInService = table.Column<bool>(nullable: false),
            //        IsTakeAwayService = table.Column<bool>(nullable: false),
            //        IsDeliveryService = table.Column<bool>(nullable: false),
            //        IsActive = table.Column<bool>(nullable: false),
            //        UPenabled = table.Column<bool>(nullable: false),
            //        Available = table.Column<bool>(nullable: false),
            //        IsSynced = table.Column<bool>(nullable: false),
            //        UPAction = table.Column<int>(nullable: false),
            //        SortOrder = table.Column<int>(nullable: true),
            //        Recommended = table.Column<bool>(nullable: false),
            //        SyncedAt = table.Column<DateTime>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StoreProducts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_StoreProducts_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProducts_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProducts_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "UPProducts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Price = table.Column<double>(nullable: false),
            //        Available = table.Column<bool>(nullable: false),
            //        IsEnabled = table.Column<bool>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        BrandId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_UPProducts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UPProducts_Brands_BrandId",
            //            column: x => x.BrandId,
            //            principalTable: "Brands",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_UPProducts_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UPProducts_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_UPProducts_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Variants",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        Price = table.Column<double>(nullable: false),
            //        SortOrder = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        VariantGroupId = table.Column<int>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        CategoryVariantGroupId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Variants", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Variants_CategoryVariantGroups_CategoryVariantGroupId",
            //            column: x => x.CategoryVariantGroupId,
            //            principalTable: "CategoryVariantGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Variants_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Variants_VariantGroups_VariantGroupId",
            //            column: x => x.VariantGroupId,
            //            principalTable: "VariantGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Orders",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        OrderNo = table.Column<int>(nullable: false),
            //        InvoiceNo = table.Column<string>(nullable: true),
            //        SourceId = table.Column<int>(nullable: true),
            //        AggregatorOrderId = table.Column<string>(nullable: true),
            //        UPOrderId = table.Column<string>(nullable: true),
            //        StoreId = table.Column<int>(nullable: true),
            //        CustomerId = table.Column<int>(nullable: true),
            //        CustomerAddressId = table.Column<int>(nullable: true),
            //        OrderStatusId = table.Column<int>(nullable: false),
            //        PreviousStatusId = table.Column<int>(nullable: true),
            //        BillAmount = table.Column<double>(nullable: false),
            //        PaidAmount = table.Column<double>(nullable: false),
            //        RefundAmount = table.Column<double>(nullable: false),
            //        Source = table.Column<string>(nullable: true),
            //        Tax1 = table.Column<double>(nullable: false),
            //        Tax2 = table.Column<double>(nullable: false),
            //        Tax3 = table.Column<double>(nullable: false),
            //        BillStatusId = table.Column<int>(nullable: false),
            //        SplitTableId = table.Column<int>(nullable: true),
            //        DiscPercent = table.Column<double>(nullable: false),
            //        DiscAmount = table.Column<double>(nullable: false),
            //        IsAdvanceOrder = table.Column<bool>(nullable: false),
            //        CustomerData = table.Column<string>(nullable: true),
            //        DiningTableId = table.Column<int>(nullable: true),
            //        WaiterId = table.Column<int>(nullable: true),
            //        OrderedDateTime = table.Column<DateTime>(nullable: false),
            //        OrderedDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        DeliveryDateTime = table.Column<DateTime>(nullable: true),
            //        BillDateTime = table.Column<DateTime>(nullable: false),
            //        BillDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        Note = table.Column<string>(nullable: true),
            //        OrderStatusDetails = table.Column<string>(nullable: true),
            //        RiderStatusDetails = table.Column<string>(nullable: true),
            //        FoodReady = table.Column<bool>(nullable: false),
            //        Closed = table.Column<bool>(nullable: false),
            //        OrderJson = table.Column<string>(nullable: true),
            //        ItemJson = table.Column<string>(nullable: true),
            //        ChargeJson = table.Column<string>(nullable: true),
            //        Charges = table.Column<double>(nullable: true),
            //        OrderDiscount = table.Column<double>(nullable: true),
            //        OrderTaxDisc = table.Column<double>(nullable: true),
            //        OrderTotDisc = table.Column<double>(nullable: true),
            //        AllItemDisc = table.Column<double>(nullable: true),
            //        AllItemTaxDisc = table.Column<double>(nullable: true),
            //        AllItemTotalDisc = table.Column<double>(nullable: true),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        UserId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        OrderType = table.Column<int>(nullable: false),
            //        AutoOrderId = table.Column<int>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        SuppliedById = table.Column<int>(nullable: false),
            //        OrderedById = table.Column<int>(nullable: false),
            //        OrderStatus = table.Column<int>(nullable: true),
            //        DispatchStatus = table.Column<int>(nullable: true),
            //        ReceiveStatus = table.Column<int>(nullable: true),
            //        CancelStatus = table.Column<int>(nullable: true),
            //        SpecialOrder = table.Column<bool>(nullable: false),
            //        WipStatus = table.Column<string>(nullable: true),
            //        ProdStatus = table.Column<string>(nullable: true),
            //        DifferentPercent = table.Column<double>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Orders", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Orders_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Orders_CustomerAddress_CustomerAddressId",
            //            column: x => x.CustomerAddressId,
            //            principalTable: "CustomerAddress",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_DiningTables_DiningTableId",
            //            column: x => x.DiningTableId,
            //            principalTable: "DiningTables",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_Contacts_OrderedById",
            //            column: x => x.OrderedById,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Orders_EnumVal_ProdStatus",
            //            column: x => x.ProdStatus,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_Contacts_SuppliedById",
            //            column: x => x.SuppliedById,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Orders_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_Users_WaiterId",
            //            column: x => x.WaiterId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Orders_EnumVal_WipStatus",
            //            column: x => x.WipStatus,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryAddons",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        AddonId = table.Column<int>(nullable: false),
            //        AddonGroupId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryAddons", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryAddons_AddonGroups_AddonGroupId",
            //            column: x => x.AddonGroupId,
            //            principalTable: "AddonGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryAddons_Addons_AddonId",
            //            column: x => x.AddonId,
            //            principalTable: "Addons",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryAddons_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryAddons_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductAddOns",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        AddOnId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: false),
            //        DeliveryPrice = table.Column<double>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductAddOns", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductAddOns_Addons_AddOnId",
            //            column: x => x.AddOnId,
            //            principalTable: "Addons",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductAddOns_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductAddOns_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StoreProductAddons",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        AddOnId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: false),
            //        DeliveryPrice = table.Column<double>(nullable: false),
            //        IsAvailable = table.Column<bool>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ProductAddonId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StoreProductAddons", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_StoreProductAddons_Addons_AddOnId",
            //            column: x => x.AddOnId,
            //            principalTable: "Addons",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductAddons_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductAddons_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductAddons_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Batches",
            //    columns: table => new
            //    {
            //        BatchId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        BatchNo = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        Quantity = table.Column<double>(nullable: false),
            //        BarcodeId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ExpiaryDate = table.Column<DateTime>(nullable: true),
            //        EntryDateTime = table.Column<DateTime>(nullable: false),
            //        Price = table.Column<double>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Batches", x => x.BatchId);
            //        table.ForeignKey(
            //            name: "FK_Batches_Barcodes_BarcodeId",
            //            column: x => x.BarcodeId,
            //            principalTable: "Barcodes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Batches_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Batches_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Batches_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Stocks",
            //    columns: table => new
            //    {
            //        StockId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        ProdStoreId = table.Column<int>(nullable: true),
            //        StorageStoreId = table.Column<int>(nullable: true),
            //        IsAutoProduction = table.Column<bool>(nullable: false),
            //        IsDispatchProduction = table.Column<bool>(nullable: false),
            //        IsPOSImportProduction = table.Column<bool>(nullable: false),
            //        IsStockUpdProduction = table.Column<bool>(nullable: false),
            //        SortOrder = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        BarcodeId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Stocks", x => x.StockId);
            //        table.ForeignKey(
            //            name: "FK_Stocks_Barcodes_BarcodeId",
            //            column: x => x.BarcodeId,
            //            principalTable: "Barcodes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Stocks_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Stocks_Users_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Stocks_Stores_ProdStoreId",
            //            column: x => x.ProdStoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Stocks_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Stocks_Stores_StorageStoreId",
            //            column: x => x.StorageStoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Stocks_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StoreProductOptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        OptionId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: true),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        UPPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ProductOptionId = table.Column<int>(nullable: false),
            //        MappedProductId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StoreProductOptions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_StoreProductOptions_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductOptions_Products_MappedProductId",
            //            column: x => x.MappedProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_StoreProductOptions_Options_OptionId",
            //            column: x => x.OptionId,
            //            principalTable: "Options",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductOptions_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductOptions_ProductOptions_ProductOptionId",
            //            column: x => x.ProductOptionId,
            //            principalTable: "ProductOptions",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductOptions_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BarcodeVariants",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        BarcodeId = table.Column<int>(nullable: false),
            //        VariantId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BarcodeVariants", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_BarcodeVariants_Barcodes_BarcodeId",
            //            column: x => x.BarcodeId,
            //            principalTable: "Barcodes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BarcodeVariants_Variants_VariantId",
            //            column: x => x.VariantId,
            //            principalTable: "Variants",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryOptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CategoryId = table.Column<int>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        OptionId = table.Column<int>(nullable: false),
            //        OptionGroupId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        UPPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryOptions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryOptions_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryOptions_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryOptions_OptionGroups_OptionGroupId",
            //            column: x => x.OptionGroupId,
            //            principalTable: "OptionGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryOptions_Variants_OptionId",
            //            column: x => x.OptionId,
            //            principalTable: "Variants",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CategoryVariants",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        CategoryId = table.Column<int>(nullable: false),
            //        VariantId = table.Column<int>(nullable: false),
            //        VariantGroupId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CategoryVariants", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CategoryVariants_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryVariants_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryVariants_VariantGroups_VariantGroupId",
            //            column: x => x.VariantGroupId,
            //            principalTable: "VariantGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_CategoryVariants_Variants_VariantId",
            //            column: x => x.VariantId,
            //            principalTable: "Variants",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductVariants",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        VariantId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductVariants", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ProductVariants_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductVariants_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ProductVariants_Variants_VariantId",
            //            column: x => x.VariantId,
            //            principalTable: "Variants",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StoreProductVariants",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false),
            //        VariantId = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: true),
            //        TakeawayPrice = table.Column<double>(nullable: true),
            //        DeliveryPrice = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ProductVariantId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StoreProductVariants", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_StoreProductVariants_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductVariants_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductVariants_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StoreProductVariants_Variants_VariantId",
            //            column: x => x.VariantId,
            //            principalTable: "Variants",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Bill",
            //    columns: table => new
            //    {
            //        BillId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        InVoiceNum = table.Column<string>(nullable: true),
            //        BillType = table.Column<int>(nullable: false),
            //        DispatchType = table.Column<int>(nullable: true),
            //        BillAmount = table.Column<double>(nullable: false),
            //        BillAmountNoTax = table.Column<double>(nullable: false),
            //        TaxAmount = table.Column<double>(nullable: false),
            //        DueDate = table.Column<DateTime>(nullable: true),
            //        PaidAmount = table.Column<double>(nullable: false),
            //        Quantity = table.Column<double>(nullable: true),
            //        ProviderId = table.Column<int>(nullable: false),
            //        ReceiverId = table.Column<int>(nullable: false),
            //        DispatchById = table.Column<int>(nullable: true),
            //        ReceivedById = table.Column<int>(nullable: true),
            //        PaymentStoreId = table.Column<int>(nullable: true),
            //        RecurDate = table.Column<DateTime>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        BillDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        DispatchedDate = table.Column<DateTime>(nullable: true),
            //        ReceivedDate = table.Column<DateTime>(nullable: true),
            //        ReturnedDate = table.Column<DateTime>(nullable: true),
            //        ReceiveStatus = table.Column<int>(nullable: true),
            //        ReceiveLater = table.Column<bool>(nullable: false),
            //        DispatchLater = table.Column<bool>(nullable: false),
            //        SoftCopy = table.Column<byte[]>(nullable: true),
            //        IsReturn = table.Column<bool>(nullable: false),
            //        DiscPercent = table.Column<double>(nullable: false),
            //        DiscAmount = table.Column<double>(nullable: false),
            //        TotalDiscount = table.Column<double>(nullable: false),
            //        IsPaid = table.Column<bool>(nullable: true),
            //        CreditTypeStr = table.Column<string>(nullable: true),
            //        ResponsibleById = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        ShowAllProd = table.Column<bool>(nullable: true),
            //        OrderId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bill", x => x.BillId);
            //        table.ForeignKey(
            //            name: "FK_Bill_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Bill_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Bill_EnumVal_CreditTypeStr",
            //            column: x => x.CreditTypeStr,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Bill_Contacts_DispatchById",
            //            column: x => x.DispatchById,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Bill_Orders_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Orders",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Bill_Contacts_PaymentStoreId",
            //            column: x => x.PaymentStoreId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Bill_Contacts_ProviderId",
            //            column: x => x.ProviderId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Bill_Contacts_ReceivedById",
            //            column: x => x.ReceivedById,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Bill_Contacts_ReceiverId",
            //            column: x => x.ReceiverId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Bill_Contacts_ResponsibleById",
            //            column: x => x.ResponsibleById,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "KOT",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        KOTStatusId = table.Column<int>(nullable: false),
            //        Instruction = table.Column<string>(nullable: true),
            //        KOTNo = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        OrderId = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        ModifiedDate = table.Column<DateTime>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: true),
            //        KOTGroupId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_KOT", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_KOT_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_KOT_KOTGroups_KOTGroupId",
            //            column: x => x.KOTGroupId,
            //            principalTable: "KOTGroups",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_KOT_Orders_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Orders",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_KOT_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Transactions",
            //    columns: table => new
            //    {
            //        TransactionId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Amount = table.Column<double>(nullable: false),
            //        Updated = table.Column<bool>(nullable: false),
            //        OrderId = table.Column<int>(nullable: true),
            //        CustomerId = table.Column<int>(nullable: true),
            //        PaymentTypeId = table.Column<int>(nullable: false),
            //        TranstypeId = table.Column<int>(nullable: false),
            //        PaymentStatusId = table.Column<int>(nullable: true),
            //        TransDateTime = table.Column<DateTime>(nullable: false),
            //        TransDate = table.Column<DateTime>(type: "Date", nullable: false),
            //        UserId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        Notes = table.Column<string>(nullable: true),
            //        Description = table.Column<string>(nullable: true),
            //        TransModeId = table.Column<int>(nullable: false),
            //        IsIncoming = table.Column<bool>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        BankAccountId = table.Column<int>(nullable: true),
            //        ContactId = table.Column<int>(nullable: false),
            //        DueDate = table.Column<DateTime>(nullable: true),
            //        IsReturn = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Transactions", x => x.TransactionId);
            //        table.ForeignKey(
            //            name: "FK_Transactions_BankAccounts_BankAccountId",
            //            column: x => x.BankAccountId,
            //            principalTable: "BankAccounts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Contacts_ContactId",
            //            column: x => x.ContactId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Orders_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Orders",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Transactions_PaymentTypes_PaymentTypeId",
            //            column: x => x.PaymentTypeId,
            //            principalTable: "PaymentTypes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Transactions_Users_UserId",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StockBatches",
            //    columns: table => new
            //    {
            //        StockBatchId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        StockId = table.Column<int>(nullable: false),
            //        BatchId = table.Column<int>(nullable: true),
            //        Quantity = table.Column<double>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StockBatches", x => x.StockBatchId);
            //        table.ForeignKey(
            //            name: "FK_StockBatches_Batches_BatchId",
            //            column: x => x.BatchId,
            //            principalTable: "Batches",
            //            principalColumn: "BatchId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_StockBatches_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StockBatches_Users_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_StockBatches_Stocks_StockId",
            //            column: x => x.StockId,
            //            principalTable: "Stocks",
            //            principalColumn: "StockId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BillPay",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        BillId = table.Column<int>(nullable: false),
            //        TransactionId = table.Column<int>(nullable: true),
            //        Amount = table.Column<double>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BillPay", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_BillPay_Bill_BillId",
            //            column: x => x.BillId,
            //            principalTable: "Bill",
            //            principalColumn: "BillId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BillPay_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BillPay_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_BillPay_Transactions_TransactionId",
            //            column: x => x.TransactionId,
            //            principalTable: "Transactions",
            //            principalColumn: "TransactionId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "BillTrans",
            //    columns: table => new
            //    {
            //        BillTransId = table.Column<int>(nullable: false),
            //        BillId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BillTrans", x => x.BillTransId);
            //        table.ForeignKey(
            //            name: "FK_BillTrans_Bill_BillId",
            //            column: x => x.BillId,
            //            principalTable: "Bill",
            //            principalColumn: "BillId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BillTrans_Transactions_BillTransId",
            //            column: x => x.BillTransId,
            //            principalTable: "Transactions",
            //            principalColumn: "TransactionId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BillTrans_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cheques",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ChequeNo = table.Column<string>(nullable: true),
            //        Amount = table.Column<double>(nullable: false),
            //        IssuedTrxId = table.Column<int>(nullable: false),
            //        ChequeDate = table.Column<DateTime>(nullable: false),
            //        ClearedTrxId = table.Column<int>(nullable: true),
            //        Status = table.Column<int>(nullable: false),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cheques", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Cheques_Transactions_ClearedTrxId",
            //            column: x => x.ClearedTrxId,
            //            principalTable: "Transactions",
            //            principalColumn: "TransactionId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Cheques_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Cheques_Transactions_IssuedTrxId",
            //            column: x => x.IssuedTrxId,
            //            principalTable: "Transactions",
            //            principalColumn: "TransactionId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "StockUpdate",
            //    columns: table => new
            //    {
            //        StockUpdateId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        StockBatchId = table.Column<int>(nullable: false),
            //        UpdatedQty = table.Column<double>(nullable: false),
            //        OldQty = table.Column<double>(nullable: false),
            //        OldQtyAct = table.Column<double>(nullable: false),
            //        StockUpdDate = table.Column<DateTime>(type: "Date", nullable: true),
            //        StockUpdDateTime = table.Column<DateTime>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: false),
            //        StockContainerId = table.Column<int>(nullable: true),
            //        GrossQty = table.Column<double>(nullable: true),
            //        ContainerWight = table.Column<double>(nullable: true),
            //        ContainerCount = table.Column<double>(nullable: true),
            //        IsManual = table.Column<bool>(nullable: true),
            //        GrossQtyText = table.Column<string>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        Actions = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_StockUpdate", x => x.StockUpdateId);
            //        table.ForeignKey(
            //            name: "FK_StockUpdate_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StockUpdate_StockBatches_StockBatchId",
            //            column: x => x.StockBatchId,
            //            principalTable: "StockBatches",
            //            principalColumn: "StockBatchId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_StockUpdate_StockContainer_StockContainerId",
            //            column: x => x.StockContainerId,
            //            principalTable: "StockContainer",
            //            principalColumn: "StockContainerId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Updated = table.Column<bool>(nullable: false),
            //        DiscPercent = table.Column<double>(nullable: false),
            //        DiscAmount = table.Column<double>(nullable: false),
            //        ItemDiscount = table.Column<double>(nullable: true),
            //        TaxItemDiscount = table.Column<double>(nullable: true),
            //        OrderDiscount = table.Column<double>(nullable: true),
            //        TaxOrderDiscount = table.Column<double>(nullable: true),
            //        StatusId = table.Column<int>(nullable: false),
            //        KitchenUserId = table.Column<int>(nullable: true),
            //        KOTId = table.Column<int>(nullable: true),
            //        Note = table.Column<string>(nullable: true),
            //        Message = table.Column<string>(nullable: true),
            //        TotalAmount = table.Column<double>(nullable: true),
            //        Extra = table.Column<double>(nullable: true),
            //        CategoryId = table.Column<int>(nullable: true),
            //        OptionJson = table.Column<string>(nullable: true),
            //        ComplementryQty = table.Column<float>(nullable: true),
            //        OrderItemId = table.Column<int>(nullable: false),
            //        OrderId = table.Column<int>(nullable: true),
            //        ProductId = table.Column<int>(nullable: false),
            //        OrderQuantity = table.Column<double>(nullable: true),
            //        DispatchedQuantity = table.Column<double>(nullable: true),
            //        ReceivedQuantity = table.Column<double>(nullable: true),
            //        ReturnedQuantity = table.Column<double>(nullable: true),
            //        CancelledQuantity = table.Column<double>(nullable: true),
            //        ReceiveLaterQuantity = table.Column<double>(nullable: true),
            //        DispatchLaterQuantity = table.Column<double>(nullable: true),
            //        RefId = table.Column<string>(nullable: true),
            //        Price = table.Column<double>(nullable: true),
            //        TaxAmount = table.Column<double>(nullable: true),
            //        Tax1 = table.Column<double>(nullable: true),
            //        Tax2 = table.Column<double>(nullable: true),
            //        Tax3 = table.Column<double>(nullable: true),
            //        Tax4 = table.Column<double>(nullable: true),
            //        Amount = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        Status = table.Column<int>(nullable: true),
            //        DispatchStorageId = table.Column<int>(nullable: true),
            //        DispatchStorageName = table.Column<string>(nullable: true),
            //        PendingQty = table.Column<double>(nullable: true),
            //        CurrentStock = table.Column<double>(nullable: true),
            //        AutoOrderId = table.Column<int>(nullable: true),
            //        OrderLevel = table.Column<double>(nullable: true),
            //        StockUpdateId = table.Column<int>(nullable: true),
            //        OldStock = table.Column<double>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        BarcodeId = table.Column<int>(nullable: true),
            //        VarianceReasonStr = table.Column<string>(nullable: true),
            //        VarianceReasonDesc = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderItems", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_AutoOrder_AutoOrderId",
            //            column: x => x.AutoOrderId,
            //            principalTable: "AutoOrder",
            //            principalColumn: "AutoOrderId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Barcodes_BarcodeId",
            //            column: x => x.BarcodeId,
            //            principalTable: "Barcodes",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Categories_CategoryId",
            //            column: x => x.CategoryId,
            //            principalTable: "Categories",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_KOT_KOTId",
            //            column: x => x.KOTId,
            //            principalTable: "KOT",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Users_KitchenUserId",
            //            column: x => x.KitchenUserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Orders_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Orders",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_StockUpdate_StockUpdateId",
            //            column: x => x.StockUpdateId,
            //            principalTable: "StockUpdate",
            //            principalColumn: "StockUpdateId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItems_EnumVal_VarianceReasonStr",
            //            column: x => x.VarianceReasonStr,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderProducts",
            //    columns: table => new
            //    {
            //        OrderProductId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        OrderId = table.Column<int>(nullable: true),
            //        ProductId = table.Column<int>(nullable: false),
            //        OrderQuantity = table.Column<double>(nullable: true),
            //        DispatchedQuantity = table.Column<double>(nullable: true),
            //        ReceivedQuantity = table.Column<double>(nullable: true),
            //        ReturnedQuantity = table.Column<double>(nullable: true),
            //        CancelledQuantity = table.Column<double>(nullable: true),
            //        ReceiveLaterQuantity = table.Column<double>(nullable: true),
            //        DispatchLaterQuantity = table.Column<double>(nullable: true),
            //        Price = table.Column<double>(nullable: true),
            //        TaxAmount = table.Column<double>(nullable: true),
            //        Tax1 = table.Column<double>(nullable: true),
            //        Tax2 = table.Column<double>(nullable: true),
            //        Tax3 = table.Column<double>(nullable: true),
            //        Tax4 = table.Column<double>(nullable: true),
            //        Amount = table.Column<double>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        Status = table.Column<int>(nullable: true),
            //        DiscAmount = table.Column<int>(nullable: false),
            //        DiscPercent = table.Column<int>(nullable: false),
            //        PendingQty = table.Column<double>(nullable: true),
            //        CurrentStock = table.Column<double>(nullable: true),
            //        AutoOrderId = table.Column<int>(nullable: true),
            //        OrderLevel = table.Column<double>(nullable: true),
            //        StockUpdateId = table.Column<int>(nullable: true),
            //        OldStock = table.Column<double>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        VarianceReasonStr = table.Column<string>(nullable: true),
            //        VarianceReasonDesc = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderProducts", x => x.OrderProductId);
            //        table.ForeignKey(
            //            name: "FK_OrderProducts_AutoOrder_AutoOrderId",
            //            column: x => x.AutoOrderId,
            //            principalTable: "AutoOrder",
            //            principalColumn: "AutoOrderId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderProducts_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderProducts_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderProducts_Orders_OrderId",
            //            column: x => x.OrderId,
            //            principalTable: "Orders",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderProducts_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderProducts_StockUpdate_StockUpdateId",
            //            column: x => x.StockUpdateId,
            //            principalTable: "StockUpdate",
            //            principalColumn: "StockUpdateId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderProducts_EnumVal_VarianceReasonStr",
            //            column: x => x.VarianceReasonStr,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderItemDetails",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        OrderItemDetailId = table.Column<int>(nullable: false),
            //        OrderItemId = table.Column<int>(nullable: false),
            //        ActualProdId = table.Column<int>(nullable: true),
            //        BatchId = table.Column<int>(nullable: true),
            //        BillId = table.Column<int>(nullable: true),
            //        OrderItemType = table.Column<int>(nullable: false),
            //        StorageStoreId = table.Column<int>(nullable: true),
            //        ContatinerId = table.Column<int>(nullable: true),
            //        ContainerCount = table.Column<int>(nullable: true),
            //        Quantity = table.Column<double>(nullable: false),
            //        UnitPrice = table.Column<double>(nullable: true),
            //        Tax1 = table.Column<double>(nullable: true),
            //        Tax2 = table.Column<double>(nullable: true),
            //        Amount = table.Column<double>(nullable: true),
            //        TaxAmount = table.Column<double>(nullable: true),
            //        Date = table.Column<DateTime>(type: "Date", nullable: true),
            //        DateTime = table.Column<DateTime>(nullable: true),
            //        RelatedOrderId = table.Column<int>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        OrderItemRefId = table.Column<string>(nullable: true),
            //        DiscAmount = table.Column<double>(nullable: false),
            //        DiscPercent = table.Column<double>(nullable: false),
            //        DiscPerQty = table.Column<double>(nullable: false),
            //        AutoOrderId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        VarianceReasonStr = table.Column<string>(nullable: true),
            //        VarianceReasonDesc = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderItemDetails", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_Products_ActualProdId",
            //            column: x => x.ActualProdId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_AutoOrder_AutoOrderId",
            //            column: x => x.AutoOrderId,
            //            principalTable: "AutoOrder",
            //            principalColumn: "AutoOrderId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_Batches_BatchId",
            //            column: x => x.BatchId,
            //            principalTable: "Batches",
            //            principalColumn: "BatchId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_Bill_BillId",
            //            column: x => x.BillId,
            //            principalTable: "Bill",
            //            principalColumn: "BillId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_StockContainer_ContatinerId",
            //            column: x => x.ContatinerId,
            //            principalTable: "StockContainer",
            //            principalColumn: "StockContainerId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_OrderItems_OrderItemId",
            //            column: x => x.OrderItemId,
            //            principalTable: "OrderItems",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_Stores_StorageStoreId",
            //            column: x => x.StorageStoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderItemDetails_EnumVal_VarianceReasonStr",
            //            column: x => x.VarianceReasonStr,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrdProdDetails",
            //    columns: table => new
            //    {
            //        OrdProdDetailId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        OrderProductId = table.Column<int>(nullable: false),
            //        ActualProdId = table.Column<int>(nullable: true),
            //        BatchId = table.Column<int>(nullable: true),
            //        BillId = table.Column<int>(nullable: true),
            //        OrdProdType = table.Column<int>(nullable: false),
            //        StorageStoreId = table.Column<int>(nullable: true),
            //        ContatinerId = table.Column<int>(nullable: true),
            //        ContainerCount = table.Column<int>(nullable: true),
            //        Quantity = table.Column<double>(nullable: false),
            //        UnitPrice = table.Column<double>(nullable: true),
            //        Tax1 = table.Column<double>(nullable: true),
            //        Tax2 = table.Column<double>(nullable: true),
            //        Amount = table.Column<double>(nullable: true),
            //        TaxAmount = table.Column<double>(nullable: true),
            //        Date = table.Column<DateTime>(type: "Date", nullable: true),
            //        DateTime = table.Column<DateTime>(nullable: true),
            //        RelatedOrderId = table.Column<int>(nullable: true),
            //        CreatedDate = table.Column<DateTime>(nullable: true),
            //        CreatedBy = table.Column<int>(nullable: true),
            //        DiscAmount = table.Column<double>(nullable: false),
            //        DiscPercent = table.Column<double>(nullable: false),
            //        DiscPerQty = table.Column<double>(nullable: false),
            //        AutoOrderId = table.Column<int>(nullable: true),
            //        CompanyId = table.Column<int>(nullable: false),
            //        VarianceReasonStr = table.Column<string>(nullable: true),
            //        VarianceReasonDesc = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrdProdDetails", x => x.OrdProdDetailId);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_Products_ActualProdId",
            //            column: x => x.ActualProdId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_AutoOrder_AutoOrderId",
            //            column: x => x.AutoOrderId,
            //            principalTable: "AutoOrder",
            //            principalColumn: "AutoOrderId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_Batches_BatchId",
            //            column: x => x.BatchId,
            //            principalTable: "Batches",
            //            principalColumn: "BatchId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_Bill_BillId",
            //            column: x => x.BillId,
            //            principalTable: "Bill",
            //            principalColumn: "BillId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_StockContainer_ContatinerId",
            //            column: x => x.ContatinerId,
            //            principalTable: "StockContainer",
            //            principalColumn: "StockContainerId",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_Contacts_CreatedBy",
            //            column: x => x.CreatedBy,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_OrderProducts_OrderProductId",
            //            column: x => x.OrderProductId,
            //            principalTable: "OrderProducts",
            //            principalColumn: "OrderProductId",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_Stores_StorageStoreId",
            //            column: x => x.StorageStoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrdProdDetails_EnumVal_VarianceReasonStr",
            //            column: x => x.VarianceReasonStr,
            //            principalTable: "EnumVal",
            //            principalColumn: "Code",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Accounts_CompanyId",
            //    table: "Accounts",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AdditionalCharges_CompanyId",
            //    table: "AdditionalCharges",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AdditionalCharges_TaxGroupId",
            //    table: "AdditionalCharges",
            //    column: "TaxGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AddonGroups_CompanyId",
            //    table: "AddonGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Addons_AddonGroupId",
            //    table: "Addons",
            //    column: "AddonGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Addons_CompanyId",
            //    table: "Addons",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Addons_ProductId",
            //    table: "Addons",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AutoOrder_CategoryId",
            //    table: "AutoOrder",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AutoOrder_CompanyId",
            //    table: "AutoOrder",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AutoOrder_CreatedBy",
            //    table: "AutoOrder",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AutoOrder_OrderStoreId",
            //    table: "AutoOrder",
            //    column: "OrderStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AutoOrder_ProductId",
            //    table: "AutoOrder",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AutoOrder_SupplierId",
            //    table: "AutoOrder",
            //    column: "SupplierId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BankAccounts_AccountTypeCd",
            //    table: "BankAccounts",
            //    column: "AccountTypeCd");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BankAccounts_CompanyId",
            //    table: "BankAccounts",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Barcodes_ProductId",
            //    table: "Barcodes",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BarcodeVariants_BarcodeId",
            //    table: "BarcodeVariants",
            //    column: "BarcodeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BarcodeVariants_VariantId",
            //    table: "BarcodeVariants",
            //    column: "VariantId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Batches_BarcodeId",
            //    table: "Batches",
            //    column: "BarcodeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Batches_CompanyId",
            //    table: "Batches",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Batches_ProductId",
            //    table: "Batches",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Batches_StoreId",
            //    table: "Batches",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_CompanyId",
            //    table: "Bill",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_CreatedBy",
            //    table: "Bill",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_CreditTypeStr",
            //    table: "Bill",
            //    column: "CreditTypeStr");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_DispatchById",
            //    table: "Bill",
            //    column: "DispatchById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_OrderId",
            //    table: "Bill",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_PaymentStoreId",
            //    table: "Bill",
            //    column: "PaymentStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_ProviderId",
            //    table: "Bill",
            //    column: "ProviderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_ReceivedById",
            //    table: "Bill",
            //    column: "ReceivedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_ReceiverId",
            //    table: "Bill",
            //    column: "ReceiverId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Bill_ResponsibleById",
            //    table: "Bill",
            //    column: "ResponsibleById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BillPay_BillId",
            //    table: "BillPay",
            //    column: "BillId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BillPay_CompanyId",
            //    table: "BillPay",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BillPay_CreatedBy",
            //    table: "BillPay",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BillPay_TransactionId",
            //    table: "BillPay",
            //    column: "TransactionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BillTrans_BillId",
            //    table: "BillTrans",
            //    column: "BillId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BillTrans_CompanyId",
            //    table: "BillTrans",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Brands_CompanyId",
            //    table: "Brands",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_CompanyId",
            //    table: "Categories",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_ParentCategoryId",
            //    table: "Categories",
            //    column: "ParentCategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryAddons_AddonGroupId",
            //    table: "CategoryAddons",
            //    column: "AddonGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryAddons_AddonId",
            //    table: "CategoryAddons",
            //    column: "AddonId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryAddons_CategoryId",
            //    table: "CategoryAddons",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryAddons_CompanyId",
            //    table: "CategoryAddons",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryOptionGroups_CategoryId",
            //    table: "CategoryOptionGroups",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryOptionGroups_CompanyId",
            //    table: "CategoryOptionGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryOptionGroups_OptionGroupId",
            //    table: "CategoryOptionGroups",
            //    column: "OptionGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryOptions_CategoryId",
            //    table: "CategoryOptions",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryOptions_CompanyId",
            //    table: "CategoryOptions",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryOptions_OptionGroupId",
            //    table: "CategoryOptions",
            //    column: "OptionGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryOptions_OptionId",
            //    table: "CategoryOptions",
            //    column: "OptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryVariantGroups_CategoryId",
            //    table: "CategoryVariantGroups",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryVariantGroups_VariantGroupId",
            //    table: "CategoryVariantGroups",
            //    column: "VariantGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryVariants_CategoryId",
            //    table: "CategoryVariants",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryVariants_CompanyId",
            //    table: "CategoryVariants",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryVariants_VariantGroupId",
            //    table: "CategoryVariants",
            //    column: "VariantGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CategoryVariants_VariantId",
            //    table: "CategoryVariants",
            //    column: "VariantId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cheques_ClearedTrxId",
            //    table: "Cheques",
            //    column: "ClearedTrxId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cheques_CompanyId",
            //    table: "Cheques",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cheques_IssuedTrxId",
            //    table: "Cheques",
            //    column: "IssuedTrxId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cnditions_CompanyId",
            //    table: "Cnditions",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cnditions_JoinOperatorId",
            //    table: "Cnditions",
            //    column: "JoinOperatorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cnditions_OperatorId",
            //    table: "Cnditions",
            //    column: "OperatorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cnditions_ParentCnditionId",
            //    table: "Cnditions",
            //    column: "ParentCnditionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cnditions_VariableTypeId",
            //    table: "Cnditions",
            //    column: "VariableTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contacts_CompanyId",
            //    table: "Contacts",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contacts_ParentContactId",
            //    table: "Contacts",
            //    column: "ParentContactId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CtTypes_CreatedBy",
            //    table: "CtTypes",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerAddress_CompanyId",
            //    table: "CustomerAddress",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerAddress_CustomerId",
            //    table: "CustomerAddress",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerOffers_CompanyId",
            //    table: "CustomerOffers",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerOffers_CustomerId",
            //    table: "CustomerOffers",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerOffers_OfferId",
            //    table: "CustomerOffers",
            //    column: "OfferId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_CompanyId",
            //    table: "Customers",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_StoreId",
            //    table: "Customers",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DiningAreas_CompanyId",
            //    table: "DiningAreas",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DiningAreas_StoreId",
            //    table: "DiningAreas",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DiningTables_CompanyId",
            //    table: "DiningTables",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DiningTables_DiningAreaId",
            //    table: "DiningTables",
            //    column: "DiningAreaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DiningTables_StoreId",
            //    table: "DiningTables",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DiscountRules_CompanyId",
            //    table: "DiscountRules",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DropDowns_DropDownGroupId",
            //    table: "DropDowns",
            //    column: "DropDownGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOT_CompanyId",
            //    table: "KOT",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOT_KOTGroupId",
            //    table: "KOT",
            //    column: "KOTGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOT_OrderId",
            //    table: "KOT",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOT_StoreId",
            //    table: "KOT",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOTGroupPrinters_CompanyId",
            //    table: "KOTGroupPrinters",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOTGroupPrinters_KOTGroupId",
            //    table: "KOTGroupPrinters",
            //    column: "KOTGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOTGroupPrinters_StoreId",
            //    table: "KOTGroupPrinters",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_KOTGroups_CompanyId",
            //    table: "KOTGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Liabilities_CompanyId",
            //    table: "Liabilities",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Liabilities_ContactId",
            //    table: "Liabilities",
            //    column: "ContactId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Liabilities_CreatedBy",
            //    table: "Liabilities",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Liabilities_LiabilityTypeId",
            //    table: "Liabilities",
            //    column: "LiabilityTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Liabilities_StoreId",
            //    table: "Liabilities",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Liabilities_VendorId",
            //    table: "Liabilities",
            //    column: "VendorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LiabilityTypes_CompanyId",
            //    table: "LiabilityTypes",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LiabilityTypes_CreatedBy",
            //    table: "LiabilityTypes",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MaintBillTypes_CompanyId",
            //    table: "MaintBillTypes",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MaintBillTypes_CreatedBy",
            //    table: "MaintBillTypes",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MaintBillTypes_LiabilityTypeId",
            //    table: "MaintBillTypes",
            //    column: "LiabilityTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OfferRules_CompanyId",
            //    table: "OfferRules",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OfferRules_OfferId",
            //    table: "OfferRules",
            //    column: "OfferId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Offers_CompanyId",
            //    table: "Offers",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OptionGroups_CompanyId",
            //    table: "OptionGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Options_CompanyId",
            //    table: "Options",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Options_OptionGroupId",
            //    table: "Options",
            //    column: "OptionGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_ActualProdId",
            //    table: "OrderItemDetails",
            //    column: "ActualProdId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_AutoOrderId",
            //    table: "OrderItemDetails",
            //    column: "AutoOrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_BatchId",
            //    table: "OrderItemDetails",
            //    column: "BatchId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_BillId",
            //    table: "OrderItemDetails",
            //    column: "BillId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_CompanyId",
            //    table: "OrderItemDetails",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_ContatinerId",
            //    table: "OrderItemDetails",
            //    column: "ContatinerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_CreatedBy",
            //    table: "OrderItemDetails",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_OrderItemId",
            //    table: "OrderItemDetails",
            //    column: "OrderItemId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_StorageStoreId",
            //    table: "OrderItemDetails",
            //    column: "StorageStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemDetails_VarianceReasonStr",
            //    table: "OrderItemDetails",
            //    column: "VarianceReasonStr");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_AutoOrderId",
            //    table: "OrderItems",
            //    column: "AutoOrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_BarcodeId",
            //    table: "OrderItems",
            //    column: "BarcodeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_CategoryId",
            //    table: "OrderItems",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_CompanyId",
            //    table: "OrderItems",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_CreatedBy",
            //    table: "OrderItems",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_KOTId",
            //    table: "OrderItems",
            //    column: "KOTId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_KitchenUserId",
            //    table: "OrderItems",
            //    column: "KitchenUserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_OrderId",
            //    table: "OrderItems",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_ProductId",
            //    table: "OrderItems",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_StockUpdateId",
            //    table: "OrderItems",
            //    column: "StockUpdateId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItems_VarianceReasonStr",
            //    table: "OrderItems",
            //    column: "VarianceReasonStr");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemTypes_CompanyId",
            //    table: "OrderItemTypes",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderItemTypes_CreatedBy",
            //    table: "OrderItemTypes",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderProducts_AutoOrderId",
            //    table: "OrderProducts",
            //    column: "AutoOrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderProducts_CompanyId",
            //    table: "OrderProducts",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderProducts_CreatedBy",
            //    table: "OrderProducts",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderProducts_OrderId",
            //    table: "OrderProducts",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderProducts_ProductId",
            //    table: "OrderProducts",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderProducts_StockUpdateId",
            //    table: "OrderProducts",
            //    column: "StockUpdateId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderProducts_VarianceReasonStr",
            //    table: "OrderProducts",
            //    column: "VarianceReasonStr");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CompanyId",
            //    table: "Orders",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CustomerAddressId",
            //    table: "Orders",
            //    column: "CustomerAddressId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CustomerId",
            //    table: "Orders",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_DiningTableId",
            //    table: "Orders",
            //    column: "DiningTableId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_OrderedById",
            //    table: "Orders",
            //    column: "OrderedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_ProdStatus",
            //    table: "Orders",
            //    column: "ProdStatus");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_StoreId",
            //    table: "Orders",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_SuppliedById",
            //    table: "Orders",
            //    column: "SuppliedById");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_UserId",
            //    table: "Orders",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_WaiterId",
            //    table: "Orders",
            //    column: "WaiterId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_WipStatus",
            //    table: "Orders",
            //    column: "WipStatus");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_ActualProdId",
            //    table: "OrdProdDetails",
            //    column: "ActualProdId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_AutoOrderId",
            //    table: "OrdProdDetails",
            //    column: "AutoOrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_BatchId",
            //    table: "OrdProdDetails",
            //    column: "BatchId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_BillId",
            //    table: "OrdProdDetails",
            //    column: "BillId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_CompanyId",
            //    table: "OrdProdDetails",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_ContatinerId",
            //    table: "OrdProdDetails",
            //    column: "ContatinerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_CreatedBy",
            //    table: "OrdProdDetails",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_OrderProductId",
            //    table: "OrdProdDetails",
            //    column: "OrderProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_StorageStoreId",
            //    table: "OrdProdDetails",
            //    column: "StorageStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrdProdDetails_VarianceReasonStr",
            //    table: "OrdProdDetails",
            //    column: "VarianceReasonStr");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlannedTrans_CompanyId",
            //    table: "PlannedTrans",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlannedTrans_ContactId",
            //    table: "PlannedTrans",
            //    column: "ContactId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlannedTrans_CreatedBy",
            //    table: "PlannedTrans",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlannedTrans_StatusCode",
            //    table: "PlannedTrans",
            //    column: "StatusCode");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PlannedTrans_StoreId",
            //    table: "PlannedTrans",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Preferences_CompanyId",
            //    table: "Preferences",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductAddonGroups_AddonGroupId",
            //    table: "ProductAddonGroups",
            //    column: "AddonGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductAddonGroups_CompanyId",
            //    table: "ProductAddonGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductAddonGroups_ProductId",
            //    table: "ProductAddonGroups",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductAddOns_AddOnId",
            //    table: "ProductAddOns",
            //    column: "AddOnId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductAddOns_CompanyId",
            //    table: "ProductAddOns",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductAddOns_ProductId",
            //    table: "ProductAddOns",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductOptionGroups_CompanyId",
            //    table: "ProductOptionGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductOptionGroups_OptionGroupId",
            //    table: "ProductOptionGroups",
            //    column: "OptionGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductOptionGroups_ProductId",
            //    table: "ProductOptionGroups",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductOptions_CompanyId",
            //    table: "ProductOptions",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductOptions_OptionId",
            //    table: "ProductOptions",
            //    column: "OptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductOptions_ProductId",
            //    table: "ProductOptions",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CategoryId",
            //    table: "Products",
            //    column: "CategoryId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_CompanyId",
            //    table: "Products",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_KOTGroupId",
            //    table: "Products",
            //    column: "KOTGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_ProductTypeId",
            //    table: "Products",
            //    column: "ProductTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_TaxGroupId",
            //    table: "Products",
            //    column: "TaxGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_UnitId",
            //    table: "Products",
            //    column: "UnitId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductVariantGroups_CompanyId",
            //    table: "ProductVariantGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductVariantGroups_ProductId",
            //    table: "ProductVariantGroups",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductVariantGroups_VariantGroupId",
            //    table: "ProductVariantGroups",
            //    column: "VariantGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductVariants_CompanyId",
            //    table: "ProductVariants",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductVariants_ProductId",
            //    table: "ProductVariants",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductVariants_VariantId",
            //    table: "ProductVariants",
            //    column: "VariantId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Results_CompanyId",
            //    table: "Results",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Results_OfferTypeId",
            //    table: "Results",
            //    column: "OfferTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Results_OperatorId",
            //    table: "Results",
            //    column: "OperatorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Results_VariableTypeId",
            //    table: "Results",
            //    column: "VariableTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScreenRules_CompanyId",
            //    table: "ScreenRules",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScreenRules_RoleId",
            //    table: "ScreenRules",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScreenRules_UserId",
            //    table: "ScreenRules",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftSummaries_CompanyId",
            //    table: "ShiftSummaries",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftSummaries_StoreId",
            //    table: "ShiftSummaries",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShiftSummaries_UserId",
            //    table: "ShiftSummaries",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockBatches_BatchId",
            //    table: "StockBatches",
            //    column: "BatchId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockBatches_CompanyId",
            //    table: "StockBatches",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockBatches_CreatedBy",
            //    table: "StockBatches",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockBatches_StockId",
            //    table: "StockBatches",
            //    column: "StockId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockContainer_CompanyId",
            //    table: "StockContainer",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockContainer_CreatedBy",
            //    table: "StockContainer",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockContainer_ProductId",
            //    table: "StockContainer",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockContainer_StoreId",
            //    table: "StockContainer",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stocks_BarcodeId",
            //    table: "Stocks",
            //    column: "BarcodeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stocks_CompanyId",
            //    table: "Stocks",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stocks_CreatedBy",
            //    table: "Stocks",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stocks_ProdStoreId",
            //    table: "Stocks",
            //    column: "ProdStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stocks_ProductId",
            //    table: "Stocks",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stocks_StorageStoreId",
            //    table: "Stocks",
            //    column: "StorageStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stocks_StoreId",
            //    table: "Stocks",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockUpdate_CompanyId",
            //    table: "StockUpdate",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockUpdate_StockBatchId",
            //    table: "StockUpdate",
            //    column: "StockBatchId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StockUpdate_StockContainerId",
            //    table: "StockUpdate",
            //    column: "StockContainerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreOptions_CompanyId",
            //    table: "StoreOptions",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreOptions_OptionId",
            //    table: "StoreOptions",
            //    column: "OptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreOptions_StoreId",
            //    table: "StoreOptions",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StorePreferences_CompanyId",
            //    table: "StorePreferences",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StorePreferences_StoreId",
            //    table: "StorePreferences",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductAddons_AddOnId",
            //    table: "StoreProductAddons",
            //    column: "AddOnId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductAddons_CompanyId",
            //    table: "StoreProductAddons",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductAddons_ProductId",
            //    table: "StoreProductAddons",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductAddons_StoreId",
            //    table: "StoreProductAddons",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductOptions_CompanyId",
            //    table: "StoreProductOptions",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductOptions_MappedProductId",
            //    table: "StoreProductOptions",
            //    column: "MappedProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductOptions_OptionId",
            //    table: "StoreProductOptions",
            //    column: "OptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductOptions_ProductId",
            //    table: "StoreProductOptions",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductOptions_ProductOptionId",
            //    table: "StoreProductOptions",
            //    column: "ProductOptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductOptions_StoreId",
            //    table: "StoreProductOptions",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProducts_CompanyId",
            //    table: "StoreProducts",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProducts_ProductId",
            //    table: "StoreProducts",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProducts_StoreId",
            //    table: "StoreProducts",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductVariants_CompanyId",
            //    table: "StoreProductVariants",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductVariants_ProductId",
            //    table: "StoreProductVariants",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductVariants_StoreId",
            //    table: "StoreProductVariants",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_StoreProductVariants_VariantId",
            //    table: "StoreProductVariants",
            //    column: "VariantId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stores_CompanyId",
            //    table: "Stores",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Stores_ParentStoreId",
            //    table: "Stores",
            //    column: "ParentStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TaxGroups_CompanyId",
            //    table: "TaxGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_BankAccountId",
            //    table: "Transactions",
            //    column: "BankAccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_CompanyId",
            //    table: "Transactions",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_ContactId",
            //    table: "Transactions",
            //    column: "ContactId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_CustomerId",
            //    table: "Transactions",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_OrderId",
            //    table: "Transactions",
            //    column: "OrderId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_PaymentTypeId",
            //    table: "Transactions",
            //    column: "PaymentTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_StoreId",
            //    table: "Transactions",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_UserId",
            //    table: "Transactions",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_TransModes_CreatedBy",
            //    table: "TransModes",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UPLogs_BrandId",
            //    table: "UPLogs",
            //    column: "BrandId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UPLogs_CompanyId",
            //    table: "UPLogs",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UPLogs_StoreId",
            //    table: "UPLogs",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UPProducts_BrandId",
            //    table: "UPProducts",
            //    column: "BrandId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UPProducts_CompanyId",
            //    table: "UPProducts",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UPProducts_ProductId",
            //    table: "UPProducts",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UPProducts_StoreId",
            //    table: "UPProducts",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UrbanPiperKeys_AccountId",
            //    table: "UrbanPiperKeys",
            //    column: "AccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UrbanPiperKeys_CompanyId",
            //    table: "UrbanPiperKeys",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UrbanPiperStores_BrandId",
            //    table: "UrbanPiperStores",
            //    column: "BrandId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UrbanPiperStores_CompanyId",
            //    table: "UrbanPiperStores",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UrbanPiperStores_StoreId",
            //    table: "UrbanPiperStores",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRoles_CompanyId",
            //    table: "UserRoles",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserRoles_RoleId",
            //    table: "UserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_AccountId",
            //    table: "Users",
            //    column: "AccountId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_CompanyId",
            //    table: "Users",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserStores_StoreId",
            //    table: "UserStores",
            //    column: "StoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserStores_UserId",
            //    table: "UserStores",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_VariantGroups_CompanyId",
            //    table: "VariantGroups",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Variants_CategoryVariantGroupId",
            //    table: "Variants",
            //    column: "CategoryVariantGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Variants_CompanyId",
            //    table: "Variants",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Variants_VariantGroupId",
            //    table: "Variants",
            //    column: "VariantGroupId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Vendors_CompanyId",
            //    table: "Vendors",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Vendors_CreatedBy",
            //    table: "Vendors",
            //    column: "CreatedBy");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Vendors_PaymentStoreId",
            //    table: "Vendors",
            //    column: "PaymentStoreId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Vendors_StoreId",
            //    table: "Vendors",
            //    column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AdditionalCharges");

            //migrationBuilder.DropTable(
            //    name: "BarcodeVariants");

            //migrationBuilder.DropTable(
            //    name: "BillPay");

            //migrationBuilder.DropTable(
            //    name: "BillTrans");

            //migrationBuilder.DropTable(
            //    name: "CategoryAddons");

            //migrationBuilder.DropTable(
            //    name: "CategoryOptionGroups");

            //migrationBuilder.DropTable(
            //    name: "CategoryOptions");

            //migrationBuilder.DropTable(
            //    name: "CategoryVariants");

            //migrationBuilder.DropTable(
            //    name: "Cheques");

            //migrationBuilder.DropTable(
            //    name: "Cnditions");

            //migrationBuilder.DropTable(
            //    name: "CtTypes");

            //migrationBuilder.DropTable(
            //    name: "CustomerOffers");

            //migrationBuilder.DropTable(
            //    name: "DiscountRules");

            //migrationBuilder.DropTable(
            //    name: "DropDowns");

            //migrationBuilder.DropTable(
            //    name: "KOTGroupPrinters");

            //migrationBuilder.DropTable(
            //    name: "Liabilities");

            //migrationBuilder.DropTable(
            //    name: "MaintBillTypes");

            //migrationBuilder.DropTable(
            //    name: "OfferRules");

            //migrationBuilder.DropTable(
            //    name: "OrderItemDetails");

            //migrationBuilder.DropTable(
            //    name: "OrderItemTypes");

            //migrationBuilder.DropTable(
            //    name: "OrdProdDetails");

            //migrationBuilder.DropTable(
            //    name: "PlannedTrans");

            //migrationBuilder.DropTable(
            //    name: "Preferences");

            //migrationBuilder.DropTable(
            //    name: "Printers");

            //migrationBuilder.DropTable(
            //    name: "ProductAddonGroups");

            //migrationBuilder.DropTable(
            //    name: "ProductAddOns");

            //migrationBuilder.DropTable(
            //    name: "ProductOptionGroups");

            //migrationBuilder.DropTable(
            //    name: "ProductVariantGroups");

            //migrationBuilder.DropTable(
            //    name: "ProductVariants");

            //migrationBuilder.DropTable(
            //    name: "Registrations");

            //migrationBuilder.DropTable(
            //    name: "Results");

            //migrationBuilder.DropTable(
            //    name: "ScreenRules");

            //migrationBuilder.DropTable(
            //    name: "ShiftSummaries");

            //migrationBuilder.DropTable(
            //    name: "StoreOptions");

            //migrationBuilder.DropTable(
            //    name: "StorePreferences");

            //migrationBuilder.DropTable(
            //    name: "StoreProductAddons");

            //migrationBuilder.DropTable(
            //    name: "StoreProductOptions");

            //migrationBuilder.DropTable(
            //    name: "StoreProducts");

            //migrationBuilder.DropTable(
            //    name: "StoreProductVariants");

            //migrationBuilder.DropTable(
            //    name: "TransModes");

            //migrationBuilder.DropTable(
            //    name: "TransTypes");

            //migrationBuilder.DropTable(
            //    name: "UPLogs");

            //migrationBuilder.DropTable(
            //    name: "UPOptionGroups");

            //migrationBuilder.DropTable(
            //    name: "UPOptions");

            //migrationBuilder.DropTable(
            //    name: "UPProducts");

            //migrationBuilder.DropTable(
            //    name: "UrbanPiperKeys");

            //migrationBuilder.DropTable(
            //    name: "UrbanPiperStores");

            //migrationBuilder.DropTable(
            //    name: "UserRoles");

            //migrationBuilder.DropTable(
            //    name: "UserStores");

            //migrationBuilder.DropTable(
            //    name: "WebhookResponses");

            //migrationBuilder.DropTable(
            //    name: "Transactions");

            //migrationBuilder.DropTable(
            //    name: "DropDownGroups");

            //migrationBuilder.DropTable(
            //    name: "Vendors");

            //migrationBuilder.DropTable(
            //    name: "LiabilityTypes");

            //migrationBuilder.DropTable(
            //    name: "Offers");

            //migrationBuilder.DropTable(
            //    name: "OrderItems");

            //migrationBuilder.DropTable(
            //    name: "Bill");

            //migrationBuilder.DropTable(
            //    name: "OrderProducts");

            //migrationBuilder.DropTable(
            //    name: "OfferTypes");

            //migrationBuilder.DropTable(
            //    name: "Operators");

            //migrationBuilder.DropTable(
            //    name: "VariableTypes");

            //migrationBuilder.DropTable(
            //    name: "Addons");

            //migrationBuilder.DropTable(
            //    name: "ProductOptions");

            //migrationBuilder.DropTable(
            //    name: "Variants");

            //migrationBuilder.DropTable(
            //    name: "Brands");

            //migrationBuilder.DropTable(
            //    name: "BankAccounts");

            //migrationBuilder.DropTable(
            //    name: "PaymentTypes");

            //migrationBuilder.DropTable(
            //    name: "KOT");

            //migrationBuilder.DropTable(
            //    name: "AutoOrder");

            //migrationBuilder.DropTable(
            //    name: "StockUpdate");

            //migrationBuilder.DropTable(
            //    name: "AddonGroups");

            //migrationBuilder.DropTable(
            //    name: "Options");

            //migrationBuilder.DropTable(
            //    name: "CategoryVariantGroups");

            //migrationBuilder.DropTable(
            //    name: "AccountType");

            //migrationBuilder.DropTable(
            //    name: "Orders");

            //migrationBuilder.DropTable(
            //    name: "StockBatches");

            //migrationBuilder.DropTable(
            //    name: "StockContainer");

            //migrationBuilder.DropTable(
            //    name: "OptionGroups");

            //migrationBuilder.DropTable(
            //    name: "VariantGroups");

            //migrationBuilder.DropTable(
            //    name: "CustomerAddress");

            //migrationBuilder.DropTable(
            //    name: "DiningTables");

            //migrationBuilder.DropTable(
            //    name: "EnumVal");

            //migrationBuilder.DropTable(
            //    name: "Batches");

            //migrationBuilder.DropTable(
            //    name: "Stocks");

            //migrationBuilder.DropTable(
            //    name: "Contacts");

            //migrationBuilder.DropTable(
            //    name: "Customers");

            //migrationBuilder.DropTable(
            //    name: "DiningAreas");

            //migrationBuilder.DropTable(
            //    name: "Barcodes");

            //migrationBuilder.DropTable(
            //    name: "Users");

            //migrationBuilder.DropTable(
            //    name: "Stores");

            //migrationBuilder.DropTable(
            //    name: "Products");

            //migrationBuilder.DropTable(
            //    name: "Accounts");

            //migrationBuilder.DropTable(
            //    name: "Roles");

            //migrationBuilder.DropTable(
            //    name: "Categories");

            //migrationBuilder.DropTable(
            //    name: "KOTGroups");

            //migrationBuilder.DropTable(
            //    name: "ProductTypes");

            //migrationBuilder.DropTable(
            //    name: "TaxGroups");

            //migrationBuilder.DropTable(
            //    name: "Units");

            //migrationBuilder.DropTable(
            //    name: "Companies");
        }
    }
}
