using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaPersonal.Migrations
{
    public partial class MigrationFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolizaCoberturasModels_CoberturasPolizaModels_CoberturaId",
                table: "PolizaCoberturasModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "CoberturaId",
                table: "PolizaCoberturasModels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PolizaCoberturasModels_CoberturasPolizaModels_CoberturaId",
                table: "PolizaCoberturasModels",
                column: "CoberturaId",
                principalTable: "CoberturasPolizaModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolizaCoberturasModels_CoberturasPolizaModels_CoberturaId",
                table: "PolizaCoberturasModels");

            migrationBuilder.AlterColumn<Guid>(
                name: "CoberturaId",
                table: "PolizaCoberturasModels",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PolizaCoberturasModels_CoberturasPolizaModels_CoberturaId",
                table: "PolizaCoberturasModels",
                column: "CoberturaId",
                principalTable: "CoberturasPolizaModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
