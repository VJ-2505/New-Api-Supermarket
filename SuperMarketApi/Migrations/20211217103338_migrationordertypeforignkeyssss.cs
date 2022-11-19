using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class migrationordertypeforignkeyssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "kotprinter",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "OrderTypeId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryStoreId",
                table: "Orders",
                column: "DeliveryStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_DeliveryStoreId",
                table: "Orders",
                column: "DeliveryStoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_DeliveryStoreId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryStoreId",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "Updated",
                table: "Stores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "kotprinter",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderTypeId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }
    }
}
