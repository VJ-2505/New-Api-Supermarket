using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class aksndjkasdbnajsbddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorePaymentTypeId",
                table: "Transactions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StorePaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MachineId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Hidden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorePaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorePaymentTypes_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StorePaymentTypes_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StorePaymentTypeId",
                table: "Transactions",
                column: "StorePaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePaymentTypes_CompanyId",
                table: "StorePaymentTypes",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StorePaymentTypes_StoreId",
                table: "StorePaymentTypes",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_StorePaymentTypes_StorePaymentTypeId",
                table: "Transactions",
                column: "StorePaymentTypeId",
                principalTable: "StorePaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_StorePaymentTypes_StorePaymentTypeId",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "StorePaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StorePaymentTypeId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StorePaymentTypeId",
                table: "Transactions");
        }
    }
}
