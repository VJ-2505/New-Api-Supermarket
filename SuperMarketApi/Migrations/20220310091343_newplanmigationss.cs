using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class newplanmigationss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "Plans",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_CompanyId",
                table: "Plans",
                column: "CompanyId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Plans_Companies_CompanyId",
            //    table: "Plans",
            //    column: "CompanyId",
            //    principalTable: "Companies",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Companies_CompanyId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_CompanyId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "isactive",
                table: "Plans");
        }
    }
}
