using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class newplanmigationasas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanId",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_PlanId",
                table: "Companies",
                column: "PlanId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Companies_Plans_PlanId",
            //    table: "Companies",
            //    column: "PlanId",
            //    principalTable: "Plans",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Companies_Plans_PlanId",
            //    table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_PlanId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "Companies");
        }
    }
}
