using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gmlu.Demo.EntityFramework.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raspberry",
                columns: table => new
                {
                    RaspberryId = table.Column<Guid>(nullable: false),
                    IPadress = table.Column<string>(maxLength: 15, nullable: false),
                    Name = table.Column<string>(maxLength: 130, nullable: false),
                    location = table.Column<string>(maxLength: 130, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspberry", x => x.RaspberryId);
                });

            migrationBuilder.CreateTable(
                name: "MeasurePoint",
                columns: table => new
                {
                    MeasurePointId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Temp = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Humidity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RaspberryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurePoint", x => x.MeasurePointId);
                    table.ForeignKey(
                        name: "FK_MeasurePoint_Raspberry_RaspberryId",
                        column: x => x.RaspberryId,
                        principalTable: "Raspberry",
                        principalColumn: "RaspberryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasurePoint_RaspberryId",
                table: "MeasurePoint",
                column: "RaspberryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurePoint");

            migrationBuilder.DropTable(
                name: "Raspberry");
        }
    }
}
