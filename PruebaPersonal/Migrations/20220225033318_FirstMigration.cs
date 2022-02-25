using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaPersonal.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutomotoresModels",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieneInspeccion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomotoresModels", x => x.Placa);
                });

            migrationBuilder.CreateTable(
                name: "ClientesModels",
                columns: table => new
                {
                    IdentificacionCliente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CiudadResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionResidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutomotorPlaca = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesModels", x => x.IdentificacionCliente);
                    table.ForeignKey(
                        name: "FK_ClientesModels_AutomotoresModels_AutomotorPlaca",
                        column: x => x.AutomotorPlaca,
                        principalTable: "AutomotoresModels",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolizasModels",
                columns: table => new
                {
                    NumeroPoliza = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaPoliza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMaximoCubierto = table.Column<double>(type: "float", nullable: false),
                    NombrePlanPoliza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteIdentificacionCliente = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolizasModels", x => x.NumeroPoliza);
                    table.ForeignKey(
                        name: "FK_PolizasModels_ClientesModels_ClienteIdentificacionCliente",
                        column: x => x.ClienteIdentificacionCliente,
                        principalTable: "ClientesModels",
                        principalColumn: "IdentificacionCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoberturasPolizaModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolizaModelsNumeroPoliza = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoberturasPolizaModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoberturasPolizaModels_PolizasModels_PolizaModelsNumeroPoliza",
                        column: x => x.PolizaModelsNumeroPoliza,
                        principalTable: "PolizasModels",
                        principalColumn: "NumeroPoliza",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesModels_AutomotorPlaca",
                table: "ClientesModels",
                column: "AutomotorPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_CoberturasPolizaModels_PolizaModelsNumeroPoliza",
                table: "CoberturasPolizaModels",
                column: "PolizaModelsNumeroPoliza");

            migrationBuilder.CreateIndex(
                name: "IX_PolizasModels_ClienteIdentificacionCliente",
                table: "PolizasModels",
                column: "ClienteIdentificacionCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoberturasPolizaModels");

            migrationBuilder.DropTable(
                name: "PolizasModels");

            migrationBuilder.DropTable(
                name: "ClientesModels");

            migrationBuilder.DropTable(
                name: "AutomotoresModels");
        }
    }
}
