using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class diningtableandforiegnasbeenremobed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DiningTables_DiningTableId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_WaiterId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DiningTables");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DiningTableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DiningTableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FoodReady",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WaiterId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiningTableId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FoodReady",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WaiterId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiningTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DiningAreaId = table.Column<int>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    TableStatusId = table.Column<int>(nullable: false),
                    Updated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiningTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiningTables_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiningTables_DiningAreas_DiningAreaId",
                        column: x => x.DiningAreaId,
                        principalTable: "DiningAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiningTables_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiningTableId",
                table: "Orders",
                column: "DiningTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaiterId",
                table: "Orders",
                column: "WaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningTables_CompanyId",
                table: "DiningTables",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningTables_DiningAreaId",
                table: "DiningTables",
                column: "DiningAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_DiningTables_StoreId",
                table: "DiningTables",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DiningTables_DiningTableId",
                table: "Orders",
                column: "DiningTableId",
                principalTable: "DiningTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_WaiterId",
                table: "Orders",
                column: "WaiterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
