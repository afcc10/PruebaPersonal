using PruebaPersonal.Data;
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
        private readonly SeguroContext seguroContext;

        public Poliza(SeguroContext seguroContext)
        {
            this.seguroContext = seguroContext;
        }

        public IEnumerable<PolizaModels> ConsultaPolizas(string numeroPoliza, string placa)
        { 
            var polizaModels = seguroContext.ConsultaPolizaxPlacaoNumero(numeroPoliza, placa);

            return polizaModels;
        }

        public PolizaModels Crear(PolizaDto poliza)
        {
            PolizaModels data = new();
            PolizaCoberturasModels polizaCoberturasModels = new();

            ClienteModels clienteModels = seguroContext.ClientesModels
                                                        .Where(x => x.IdentificacionCliente.Equals(poliza.NumeroidentificacionCliente))
                                                        .FirstOrDefault();

            CoberturaPolizaModels coberturaPolizaModels = seguroContext.CoberturasPolizaModels
                                                                        .Where(x => x.Id == Guid.Parse(poliza.IdCobertura))
                                                                        .FirstOrDefault();

            string numeroPoliza = seguroContext.PolizasModels
                                                .Where(x => x.ClienteIdentificacionCliente.Equals(poliza.NumeroidentificacionCliente)
                                                    && ((x.FechaInicioPoliza.Date >= poliza.FechaInicioPoliza.Date && x.FechaFinPoliza.Date <= poliza.FechaInicioPoliza.Date) ||
                                                    x.FechaInicioPoliza.Date >= poliza.FechaFinPoliza.Date && x.FechaFinPoliza.Date <= poliza.FechaInicioPoliza.Date))
                                        .Select(x=>x.NumeroPoliza).FirstOrDefault();

            

            if (clienteModels == null || !String.IsNullOrEmpty(numeroPoliza))
            {
                return data;
            }
            else
            {
                data = new()
                {
                    NumeroPoliza = poliza.NumeroPoliza,
                    Cliente = clienteModels,                    
                    FechaInicioPoliza = poliza.FechaInicioPoliza,
                    FechaFinPoliza = poliza.FechaFinPoliza,
                    NombrePlanPoliza = poliza.NombrePlanPoliza,
                    ValorMaximoCubierto = poliza.ValorMaximoCubierto
                };

                polizaCoberturasModels = new()
                {
                    Id = Guid.NewGuid(),
                    Cobertura = coberturaPolizaModels,
                    poliza = data
                };

                seguroContext.Add(data);
                seguroContext.SaveChanges();

                seguroContext.Add(polizaCoberturasModels);
                seguroContext.SaveChanges();

                return data;
            }            
        }
    }
}
