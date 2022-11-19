using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class removeorderitemkotidandkitchenid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_KOT_KOTId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Users_KitchenUserId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "KOT");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_KOTId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_KitchenUserId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "KOTId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "KitchenUserId",
                table: "OrderItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsStockUpdate",
                table: "OrderItems",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "OrderCharges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Updated = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    AdditionalChargeId = table.Column<int>(nullable: false),
                    ChargePercentage = table.Column<double>(nullable: false),
                    ChargeAmount = table.Column<double>(nullable: false),
                    Tax1 = table.Column<double>(nullable: false),
                    Tax2 = table.Column<double>(nullable: false),
                    Tax3 = table.Column<double>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderCharges_AdditionalCharges_AdditionalChargeId",
                        column: x => x.AdditionalChargeId,
                        principalTable: "AdditionalCharges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderCharges_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderCharges_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderCharges_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdItemOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Updated = table.Column<bool>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdItemOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdItemOptions_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdItemOptions_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderCharges_AdditionalChargeId",
                table: "OrderCharges",
                column: "AdditionalChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCharges_CompanyId",
                table: "OrderCharges",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCharges_OrderId",
                table: "OrderCharges",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderCharges_StoreId",
                table: "OrderCharges",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdItemOptions_OptionId",
                table: "OrdItemOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdItemOptions_OrderItemId",
                table: "OrdItemOptions",
                column: "OrderItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderCharges");

            migrationBuilder.DropTable(
                name: "OrdItemOptions");

            migrationBuilder.DropColumn(
                name: "IsStockUpdate",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "KOTId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KitchenUserId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KOT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Instruction = table.Column<string>(nullable: true),
                    KOTGroupId = table.Column<int>(nullable: true),
                    KOTNo = table.Column<string>(nullable: true),
                    KOTStatusId = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    Updated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KOT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KOT_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KOT_KOTGroups_KOTGroupId",
                        column: x => x.KOTGroupId,
                        principalTable: "KOTGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KOT_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KOT_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_KOTId",
                table: "OrderItems",
                column: "KOTId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_KitchenUserId",
                table: "OrderItems",
                column: "KitchenUserId");

            migrationBuilder.CreateIndex(
                name: "IX_KOT_CompanyId",
                table: "KOT",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_KOT_KOTGroupId",
                table: "KOT",
                column: "KOTGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_KOT_OrderId",
                table: "KOT",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_KOT_StoreId",
                table: "KOT",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_KOT_KOTId",
                table: "OrderItems",
                column: "KOTId",
                principalTable: "KOT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Users_KitchenUserId",
                table: "OrderItems",
                column: "KitchenUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
