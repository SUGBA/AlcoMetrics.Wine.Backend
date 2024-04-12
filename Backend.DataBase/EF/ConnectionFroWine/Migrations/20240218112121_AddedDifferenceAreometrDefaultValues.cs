using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.EF.ConnectionFroWine.Migrations
{
    public partial class AddedDifferenceAreometrDefaultValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SugarValue",
                table: "AreometrDefaultValues",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.Sql(@"INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (1 , 1 , 0.2 , 0.15);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (2 , 2 , 0.45 , 0.25);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (3 , 3 , 0.65 , 0.4);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (4 , 4 , 0.9 , 0.5);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (5 , 5 , 1.1 , 0.65);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (6 , 6 , 1.35 , 0.8);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (7 , 7 , 1.55 , 0.9);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (8 , 8 , 1.75 , 1.05);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (9 , 9 , 2 , 1.2);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (10 , 10 , 2.2 , 1.3);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (11 , 11 , 2.45 , 1.45);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (12 , 12 , 2.65 , 1.55);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (13 , 13 , 2.9 , 1.7);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (14 , 14 , 3.1 , 1.85);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (15 , 15 , 3.3 , 1.95);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (16 , 16 , 3.55 , 2.1);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (17 , 17 , 3.75 , 2.25);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (18 , 18 , 4 , 2.35);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (19 , 19 , 4.2 , 2.5);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (20 , 20 , 4.45 , 2.6);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (21 , 21 , 4.65 , 2.75);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (22 , 22 , 4.85 , 2.9);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (23 , 23 , 5.1 , 3);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (24 , 24 , 5.3 , 3.15);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (25 , 25 , 5.55 , 3.3);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (26 , 26 , 5.75 , 3.4);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (27 , 27 , 6 , 3.55);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (28 , 28 , 6.2 , 3.65);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (29 , 29 , 6.4 , 3.8);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (30 , 30 , 6.65 , 3.95);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (31 , 31 , 6.85 , 4.05);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (32 , 32 , 7.1 , 4.2);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (33 , 33 , 7.3 , 4.3);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (34 , 34 , 7.55 , 4.45);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (35 , 35 , 7.75 , 4.6);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (36 , 36 , 7.95 , 4.7);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (37 , 37 , 8.2 , 4.85);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (38 , 38 , 8.4 , 5);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (39 , 39 , 8.65 , 5.1);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (40 , 40 , 8.85 , 5.25);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (41 , 41 , 9.1 , 5.35);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (42 , 42 , 9.3 , 5.5);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (43 , 43 , 9.5 , 5.65);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (44 , 44 , 9.75 , 5.75);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (45 , 45 , 9.95 , 5.9);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (46 , 46 , 10.2 , 6.05);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (47 , 47 , 10.4 , 6.15);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (48 , 48 , 10.65 , 6.3);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (49 , 49 , 10.85 , 6.4);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (50 , 50 , 11.05 , 6.55);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (51 , 51 , 11.3 , 6.7);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (52 , 52 , 11.5 , 6.8);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (53 , 53 , 11.75 , 6.95);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (54 , 54 , 11.95 , 7.05);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (55 , 55 , 12.2 , 7.2);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (56 , 56 , 12.4 , 7.35);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (57 , 57 , 12.6 , 7.5);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (58 , 58 , 12.8 , 7.65);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (59 , 59 , 13 , 7.8);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (60 , 60 , 13.2 , 7.95);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (61 , 61 , 13.4 , 8.1);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (62 , 62 , 13.6 , 8.25);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (63 , 63 , 13.8 , 8.4);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (64 , 64 , 14 , 8.55);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (65 , 65 , 15.25 , 8.7);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (66 , 66 , 14.6 , 8.75);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (67 , 67 , 14.85 , 8.8);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (68 , 68 , 15.05 , 8.9);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (69 , 69 , 15.3 , 9.05);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (70 , 70 , 15.5 , 9.15);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (71 , 71 , 15.7 , 9.3);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (72 , 72 , 15.95 , 9.45);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (73 , 73 , 16.15 , 9.55);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (74 , 74 , 16.4 , 9.7);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (75 , 75 , 16.6 , 9.85);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (76 , 76 , 16.85 , 9.95);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (77 , 77 , 17.05 , 10.1);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (78 , 78 , 17.25 , 10.2);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (79 , 79 , 17.5 , 10.35);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (80 , 80 , 17.7 , 10.5);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (81 , 81 , 17.95 , 10.6);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (82 , 82 , 18.15 , 10.75);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (83 , 83 , 18.4 , 10.85);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (84 , 84 , 18.6 , 11);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (85 , 85 , 18.8 , 11.15);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (86 , 86 , 19.05 , 11.25);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (87 , 87 , 19.25 , 11.4);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (88 , 88 , 19.5 , 11.55);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (89 , 89 , 19.7 , 11.65);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (90 , 90 , 19.95 , 11.8);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (91 , 91 , 20.15 , 11.9);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (92 , 92 , 20.35 , 12.05);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (93 , 93 , 20.6 , 12.2);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (94 , 94 , 20.8 , 12.3);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (95 , 95 , 21.05 , 12.45);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (96 , 96 , 21.25 , 12.6);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (97 , 97 , 21.45 , 12.7);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (98 , 98 , 21.7 , 12.85);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (99 , 99 , 21.9 , 12.95);  
                                    INSERT INTO ""DifferenceAreometrDefaultValues"" VALUES (100 , 100 , 22.15 , 13.1);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DifferenceAreometrDefaultValues");

            migrationBuilder.AlterColumn<int>(
                name: "SugarValue",
                table: "AreometrDefaultValues",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
