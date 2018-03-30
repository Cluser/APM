using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace apm.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    lat = table.Column<float>(nullable: false),
                    lng = table.Column<float>(nullable: false),
                    pm01_0 = table.Column<int>(nullable: false),
                    pm02_5 = table.Column<int>(nullable: false),
                    pm10_0 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    pm01_0 = table.Column<int>(nullable: false),
                    pm02_5 = table.Column<int>(nullable: false),
                    pm10_0 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
