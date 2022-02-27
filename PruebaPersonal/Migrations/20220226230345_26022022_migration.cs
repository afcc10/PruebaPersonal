using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaPersonal.Migrations
{
    public partial class _26022022_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoberturasPolizaModels_PolizasModels_PolizaModelsNumeroPoliza",
                table: "CoberturasPolizaModels");

            migrationBuilder.DropIndex(
                name: "IX_CoberturasPolizaModels_PolizaModelsNumeroPoliza",
                table: "CoberturasPolizaModels");

            migrationBuilder.DropColumn(
                name: "PolizaModelsNumeroPoliza",
                table: "CoberturasPolizaModels");

            migrationBuilder.CreateTable(
                name: "PolizaCoberturasModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    polizaNumeroPoliza = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoberturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolizaCoberturasModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolizaCoberturasModels_CoberturasPolizaModels_CoberturaId",
                        column: x => x.CoberturaId,
                        principalTable: "CoberturasPolizaModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolizaCoberturasModels_PolizasModels_polizaNumeroPoliza",
                        column: x => x.polizaNumeroPoliza,
                        principalTable: "PolizasModels",
                        principalColumn: "NumeroPoliza",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolizaCoberturasModels_CoberturaId",
                table: "PolizaCoberturasModels",
                column: "CoberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_PolizaCoberturasModels_polizaNumeroPoliza",
                table: "PolizaCoberturasModels",
                column: "polizaNumeroPoliza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolizaCoberturasModels");

            migrationBuilder.AddColumn<string>(
                name: "PolizaModelsNumeroPoliza",
                table: "CoberturasPolizaModels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoberturasPolizaModels_PolizaModelsNumeroPoliza",
                table: "CoberturasPolizaModels",
                column: "PolizaModelsNumeroPoliza");

            migrationBuilder.AddForeignKey(
                name: "FK_CoberturasPolizaModels_PolizasModels_PolizaModelsNumeroPoliza",
                table: "CoberturasPolizaModels",
                column: "PolizaModelsNumeroPoliza",
                principalTable: "PolizasModels",
                principalColumn: "NumeroPoliza",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
