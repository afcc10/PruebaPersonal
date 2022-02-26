﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaPersonal.Data;

namespace PruebaPersonal.Migrations
{
    [DbContext(typeof(SeguroContext))]
    [Migration("20220226172113_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PruebaPersonal.Models.AutomotorModels", b =>
                {
                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TieneInspeccion")
                        .HasColumnType("bit");

                    b.HasKey("Placa");

                    b.ToTable("AutomotoresModels");
                });

            modelBuilder.Entity("PruebaPersonal.Models.ClienteModels", b =>
                {
                    b.Property<string>("IdentificacionCliente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AutomotorPlaca")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CiudadResidencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionResidencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdentificacionCliente");

                    b.HasIndex("AutomotorPlaca");

                    b.ToTable("ClientesModels");
                });

            modelBuilder.Entity("PruebaPersonal.Models.CoberturaPolizaModels", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolizaModelsNumeroPoliza")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PolizaModelsNumeroPoliza");

                    b.ToTable("CoberturasPolizaModels");
                });

            modelBuilder.Entity("PruebaPersonal.Models.PolizaModels", b =>
                {
                    b.Property<string>("NumeroPoliza")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteIdentificacionCliente")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaFinPoliza")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicioPoliza")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePlanPoliza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ValorMaximoCubierto")
                        .HasColumnType("float");

                    b.HasKey("NumeroPoliza");

                    b.HasIndex("ClienteIdentificacionCliente");

                    b.ToTable("PolizasModels");
                });

            modelBuilder.Entity("PruebaPersonal.Models.ClienteModels", b =>
                {
                    b.HasOne("PruebaPersonal.Models.AutomotorModels", "Automotor")
                        .WithMany()
                        .HasForeignKey("AutomotorPlaca");

                    b.Navigation("Automotor");
                });

            modelBuilder.Entity("PruebaPersonal.Models.CoberturaPolizaModels", b =>
                {
                    b.HasOne("PruebaPersonal.Models.PolizaModels", null)
                        .WithMany("Coberturas")
                        .HasForeignKey("PolizaModelsNumeroPoliza");
                });

            modelBuilder.Entity("PruebaPersonal.Models.PolizaModels", b =>
                {
                    b.HasOne("PruebaPersonal.Models.ClienteModels", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdentificacionCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PruebaPersonal.Models.PolizaModels", b =>
                {
                    b.Navigation("Coberturas");
                });
#pragma warning restore 612, 618
        }
    }
}
