using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class migarationforstorepaymenttypesssssasadasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "OrderLogs",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Payload = table.Column<string>(nullable: true),
            //        Error = table.Column<string>(nullable: true),
            //        Updated = table.Column<bool>(nullable: false),
            //        LoggedDateTime = table.Column<DateTime>(nullable: false),
            //        StoreId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderLogs", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_OrderLogs_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_OrderLogs_Stores_StoreId",
            //            column: x => x.StoreId,
            //            principalTable: "Stores",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderLogs_CompanyId",
            //    table: "OrderLogs",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderLogs_StoreId",
            //    table: "OrderLogs",
            //    column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "OrderLogs");
        }
    }
}
