using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaPersonal.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaPoliza",
                table: "PolizasModels",
                newName: "FechaInicioPoliza");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinPoliza",
                table: "PolizasModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinPoliza",
                table: "PolizasModels");

            migrationBuilder.RenameColumn(
                name: "FechaInicioPoliza",
                table: "PolizasModels",
                newName: "FechaPoliza");
        }
    }
}
