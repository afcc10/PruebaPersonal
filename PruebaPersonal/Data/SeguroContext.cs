﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaPersonal.Models;
using System;
using System.Linq;

namespace PruebaPersonal.Data
{
    public class SeguroContext : DbContext
    {
        public SeguroContext(DbContextOptions<SeguroContext> options) : base(options)
        {

        }
        public DbSet<AutomotorModels> AutomotoresModels { get; set; }
        public DbSet<ClienteModels> ClientesModels { get; set; }
        public DbSet<CoberturaPolizaModels> CoberturasPolizaModels { get; set; }
        public DbSet<PolizaModels> PolizasModels { get; set; }

        public  AutomotorModels MostrarAutomotores(string placa)

        {
            String sql = "sp_get_automores @placa";

            SqlParameter pamid = new SqlParameter("@placa",placa);

            return this.AutomotoresModels.FromSqlRaw(sql, pamid).SingleOrDefault();

        }

        public CoberturaPolizaModels MostrarCoberturas(Guid id)

        {
            String sql = "sp_get_coberturas @id";

            SqlParameter pamid = new SqlParameter("@id", id);

            return this.CoberturasPolizaModels.FromSqlRaw(sql, pamid).SingleOrDefault();

        }

        public PolizaModels MostrarPolizas(string numeroPolizas)

        {
            String sql = "sp_get_polizas @numeroPoliza";

            SqlParameter pamid = new SqlParameter("@numeroPoliza", numeroPolizas);

            return this.PolizasModels.FromSqlRaw(sql, pamid).SingleOrDefault();

        }

        public ClienteModels MostrarClientes(string numeroIdentificacion)

        {
            String sql = "sp_get_clientes @identificion";

            SqlParameter pamid = new SqlParameter("@identificion", numeroIdentificacion);

            return this.ClientesModels.FromSqlRaw(sql, pamid).SingleOrDefault();

        }
    }
}
