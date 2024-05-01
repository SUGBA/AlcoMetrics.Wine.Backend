using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBase.EF.ConnectionFroWine.Migrations
{
    public partial class ChangeAreometerTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StartAreometerValue",
                table: "WineTimeLines",
                type: "integer",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "StartAreometerValue",
                table: "WineTimeLines",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
