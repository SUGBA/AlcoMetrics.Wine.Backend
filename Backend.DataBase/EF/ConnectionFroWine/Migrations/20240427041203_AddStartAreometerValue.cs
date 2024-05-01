using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.EF.ConnectionFroWine.Migrations
{
    public partial class AddStartAreometerValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StartAreometerValue",
                table: "WineTimeLines",
                type: "double precision",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartAreometerValue",
                table: "WineTimeLines");
        }
    }
}
