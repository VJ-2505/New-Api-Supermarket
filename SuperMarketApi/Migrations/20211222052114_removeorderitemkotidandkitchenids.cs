using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class removeorderitemkotidandkitchenids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KOTId",
                table: "OrderItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KOT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KOTStatusId = table.Column<int>(nullable: false),
                    Instruction = table.Column<string>(nullable: true),
                    KOTNo = table.Column<string>(nullable: true),
                    Updated = table.Column<bool>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    KOTGroupId = table.Column<int>(nullable: true)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_KOT_KOTId",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "KOT");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_KOTId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "KOTId",
                table: "OrderItems");
        }
    }
}
