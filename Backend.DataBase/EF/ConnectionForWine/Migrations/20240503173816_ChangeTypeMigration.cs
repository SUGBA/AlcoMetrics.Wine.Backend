using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.EF.ConnectionForWine.Migrations
{
    public partial class ChangeTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WineIngredient_WineEvents_WineEventId",
                table: "WineIngredient");

            migrationBuilder.AddForeignKey(
                name: "FK_WineIngredient_WineEvents_WineEventId",
                table: "WineIngredient",
                column: "WineEventId",
                principalTable: "WineEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WineIngredient_WineEvents_WineEventId",
                table: "WineIngredient");

            migrationBuilder.AddForeignKey(
                name: "FK_WineIngredient_WineEvents_WineEventId",
                table: "WineIngredient",
                column: "WineEventId",
                principalTable: "WineEvents",
                principalColumn: "Id");
        }
    }
}
