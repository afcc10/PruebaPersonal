using PruebaPersonal.Data;
using PruebaPersonal.Data.Dao;
using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PruebaPersonal.BussinesLogic
{
    public class Poliza : IPoliza
    {       
        private readonly IPolizaDao polizaDao;

        public Poliza(IPolizaDao polizaDao)
        {            
            this.polizaDao = polizaDao;
        }

        public IEnumerable<PolizaModels> ConsultaPolizas(string numeroPoliza, string placa)
        { 
            var polizaModels = polizaDao.ConsultaPolizaxPlacaoNumero(numeroPoliza, placa);

            return polizaModels;
        }

        public PolizaModels Crear(PolizaDto poliza)
        {
            PolizaModels data = new();
            
            PolizaCoberturasModels polizaCoberturasModels = new();

            ClienteModels clienteModels = polizaDao.GetClientesByNumeroIdentificacionCliente(poliza.NumeroidentificacionCliente);

            CoberturaPolizaModels coberturaPolizaModels = polizaDao.GetCoberturaPolizaModelsById(poliza.IdCobertura);

            string numeroPoliza = polizaDao.GetNumeroPolizaByFechasAndIdCliente(poliza.NumeroidentificacionCliente, poliza.FechaInicioPoliza, poliza.FechaFinPoliza);


            if (clienteModels == null || !String.IsNullOrEmpty(numeroPoliza))
            {
                return data;
            }
            else
            {
                data = new()
                {
                    NumeroPoliza = poliza.NumeroPoliza,                    
                    ClienteIdentificacionCliente = poliza.NumeroidentificacionCliente,
                    FechaInicioPoliza = poliza.FechaInicioPoliza,
                    FechaFinPoliza = poliza.FechaFinPoliza,
                    NombrePlanPoliza = poliza.NombrePlanPoliza,
                    ValorMaximoCubierto = poliza.ValorMaximoCubierto
                };

                polizaCoberturasModels = new()
                {
                    Id = Guid.NewGuid(),
                    polizaNumeroPoliza = poliza.NumeroPoliza,
                    CoberturaId = Guid.Parse(poliza.IdCobertura)                   
                };

                polizaDao.CrearPoliza(data);
                polizaDao.CrearPolizaCoberturas(polizaCoberturasModels);

                data.NumeroPoliza = poliza.NumeroPoliza;

                return data;
            }
        }
    }
}
