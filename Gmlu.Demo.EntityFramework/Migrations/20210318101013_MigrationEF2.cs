using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gmlu.Demo.EntityFramework.Migrations
{
    public partial class MigrationEF2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raspberrys",
                columns: table => new
                {
                    RaspberryId = table.Column<Guid>(nullable: false),
                    IPadress = table.Column<string>(maxLength: 15, nullable: false),
                    Name = table.Column<string>(maxLength: 130, nullable: false),
                    location = table.Column<string>(maxLength: 130, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspberrys", x => x.RaspberryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raspberrys");
        }
    }
}
