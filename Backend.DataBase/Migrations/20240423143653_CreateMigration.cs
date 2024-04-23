using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    public partial class CreateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreometrDefaultValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AreometerValue = table.Column<int>(type: "integer", nullable: false),
                    SugarValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreometrDefaultValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifferenceAreometrDefaultValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DifferenceAreometerValue = table.Column<int>(type: "integer", nullable: false),
                    SugarValue = table.Column<double>(type: "double precision", nullable: false),
                    EthanolValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifferenceAreometrDefaultValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrapeVarieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    GrapeVarietyName = table.Column<string>(type: "text", nullable: false),
                    SugarValue = table.Column<double>(type: "double precision", nullable: false),
                    AcidValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrapeVarieties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    WortValue = table.Column<double>(type: "double precision", nullable: false),
                    SugarValue = table.Column<double>(type: "double precision", nullable: false),
                    NitrogenValue = table.Column<double>(type: "double precision", nullable: false),
                    YeastValue = table.Column<double>(type: "double precision", nullable: false),
                    EthanolValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineIndicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineReferenceInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Information = table.Column<string>(type: "text", nullable: false),
                    UsedModule = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineReferenceInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineTypicalEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineTypicalEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WineTimeLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TimeLineName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineTimeLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineTimeLines_WineUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "WineUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WineDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CurrentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TimeLineId = table.Column<int>(type: "integer", nullable: false),
                    IndicatorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineDays_WineIndicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "WineIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineDays_WineTimeLines_TimeLineId",
                        column: x => x.TimeLineId,
                        principalTable: "WineTimeLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WineEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    TypicalEventId = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    DayId = table.Column<int>(type: "integer", nullable: false),
                    DesiredIndicatorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineEvent_WineDays_DayId",
                        column: x => x.DayId,
                        principalTable: "WineDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineEvent_WineIndicators_DesiredIndicatorId",
                        column: x => x.DesiredIndicatorId,
                        principalTable: "WineIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineEvent_WineTypicalEvents_TypicalEventId",
                        column: x => x.TypicalEventId,
                        principalTable: "WineTypicalEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WineDays_IndicatorId",
                table: "WineDays",
                column: "IndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WineDays_TimeLineId",
                table: "WineDays",
                column: "TimeLineId");

            migrationBuilder.CreateIndex(
                name: "IX_WineEvent_DayId",
                table: "WineEvent",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_WineEvent_DesiredIndicatorId",
                table: "WineEvent",
                column: "DesiredIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WineEvent_TypicalEventId",
                table: "WineEvent",
                column: "TypicalEventId");

            migrationBuilder.CreateIndex(
                name: "IX_WineTimeLines_UserId",
                table: "WineTimeLines",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreometrDefaultValues");

            migrationBuilder.DropTable(
                name: "DifferenceAreometrDefaultValues");

            migrationBuilder.DropTable(
                name: "GrapeVarieties");

            migrationBuilder.DropTable(
                name: "WineEvent");

            migrationBuilder.DropTable(
                name: "WineReferenceInformations");

            migrationBuilder.DropTable(
                name: "WineDays");

            migrationBuilder.DropTable(
                name: "WineTypicalEvents");

            migrationBuilder.DropTable(
                name: "WineIndicators");

            migrationBuilder.DropTable(
                name: "WineTimeLines");

            migrationBuilder.DropTable(
                name: "WineUsers");
        }
    }
}
