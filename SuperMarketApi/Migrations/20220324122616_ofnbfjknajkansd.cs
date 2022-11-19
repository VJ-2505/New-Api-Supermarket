using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class ofnbfjknajkansd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "NeedProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NeedProducts_CompanyId",
                table: "NeedProducts",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_NeedProducts_Companies_CompanyId",
                table: "NeedProducts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NeedProducts_Companies_CompanyId",
                table: "NeedProducts");

            migrationBuilder.DropIndex(
                name: "IX_NeedProducts_CompanyId",
                table: "NeedProducts");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "NeedProducts");
        }
    }
}
