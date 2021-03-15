using Microsoft.EntityFrameworkCore.Migrations;

namespace Gmlu.Demo.EntityFramework.Migrations
{
    public partial class ChangedMeasurePoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Temp",
                table: "MeasurePoint",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Humidity",
                table: "MeasurePoint",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Temp",
                table: "MeasurePoint",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Humidity",
                table: "MeasurePoint",
                type: "decimal(2,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
