using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class addpurchselishtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    ProductQty = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<int>(nullable: false),
                    ProductTax = table.Column<int>(nullable: false),
                    BillAmount = table.Column<int>(nullable: false),
                    PaidAmount = table.Column<int>(nullable: false),
                    VendorName = table.Column<string>(nullable: true),
                    VendorNumber = table.Column<string>(nullable: true),
                    VendorAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseLists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseLists");
        }
    }
}
