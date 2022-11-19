using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class addcustomerplanid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Companies_Plans_PlanId",
            //    table: "Companies");

            //migrationBuilder.AlterColumn<int>(
            //    name: "PlanId",
            //    table: "Companies",
            //    nullable: true,
            //    oldClrType: typeof(int));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Companies_Plans_PlanId",
            //    table: "Companies",
            //    column: "PlanId",
            //    principalTable: "Plans",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Companies_Plans_PlanId",
        //        table: "Companies");

        //    migrationBuilder.AlterColumn<int>(
        //        name: "PlanId",
        //        table: "Companies",
        //        nullable: false,
        //        oldClrType: typeof(int),
        //        oldNullable: true);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Companies_Plans_PlanId",
        //        table: "Companies",
        //        column: "PlanId",
        //        principalTable: "Plans",
        //        principalColumn: "Id");
        }
    }
}
