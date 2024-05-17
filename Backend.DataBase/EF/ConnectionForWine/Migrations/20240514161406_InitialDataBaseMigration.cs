﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.EF.ConnectionForWine.Migrations
{
    public partial class InitialDataBaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreometrDefaultValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    StartAreometerValue = table.Column<int>(type: "integer", nullable: true),
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
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
                name: "WineEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    TypicalEventId = table.Column<int>(type: "integer", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    DayId = table.Column<int>(type: "integer", nullable: false),
                    DesiredIndicatorId = table.Column<int>(type: "integer", nullable: false),
                    ResultIndicatorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineEvents_WineDays_DayId",
                        column: x => x.DayId,
                        principalTable: "WineDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineEvents_WineIndicators_DesiredIndicatorId",
                        column: x => x.DesiredIndicatorId,
                        principalTable: "WineIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineEvents_WineIndicators_ResultIndicatorId",
                        column: x => x.ResultIndicatorId,
                        principalTable: "WineIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WineEvents_WineTypicalEvents_TypicalEventId",
                        column: x => x.TypicalEventId,
                        principalTable: "WineTypicalEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WineIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    WineEventId = table.Column<int>(type: "integer", nullable: true),
                    IngredientName = table.Column<string>(type: "text", nullable: false),
                    IngredientValue = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WineIngredient_WineEvents_WineEventId",
                        column: x => x.WineEventId,
                        principalTable: "WineEvents",
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
                name: "IX_WineEvents_DayId",
                table: "WineEvents",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_WineEvents_DesiredIndicatorId",
                table: "WineEvents",
                column: "DesiredIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WineEvents_ResultIndicatorId",
                table: "WineEvents",
                column: "ResultIndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_WineEvents_TypicalEventId",
                table: "WineEvents",
                column: "TypicalEventId");

            migrationBuilder.CreateIndex(
                name: "IX_WineIngredient_WineEventId",
                table: "WineIngredient",
                column: "WineEventId");

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
                name: "WineIngredient");

            migrationBuilder.DropTable(
                name: "WineReferenceInformations");

            migrationBuilder.DropTable(
                name: "WineEvents");

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