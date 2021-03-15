using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gmlu.Demo.EntityFramework.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurePoint",
                columns: table => new
                {
                    MeasurePointId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Temp = table.Column<decimal>(nullable: true),
                    Humidity = table.Column<decimal>(nullable: true),
                    Device = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurePoint", x => x.MeasurePointId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurePoint");
        }
    }
}
