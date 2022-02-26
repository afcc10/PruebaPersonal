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

        public PolizaModels Crear(PolizaDto poliza)
        {
            PolizaModels data = new();

            ClienteModels clienteModels = seguroContext.ClientesModels
                                                        .Where(x => x.IdentificacionCliente.Equals(poliza.NumeroidentificacionCliente))
                                                        .FirstOrDefault();

            List<CoberturaPolizaModels> coberturaPolizaModels = seguroContext.CoberturasPolizaModels
                                                                        .Where(x => x.Id == Guid.Parse(poliza.IdCobertura))
                                                                        .ToList();

            if (clienteModels == null || coberturaPolizaModels == null)
            {
                return data;
            }
            else
            {
                data = new()
                {
                    NumeroPoliza = poliza.NumeroPoliza,
                    Cliente = clienteModels,
                    Coberturas = coberturaPolizaModels,
                    FechaInicioPoliza = poliza.FechaInicioPoliza,
                    FechaFinPoliza = poliza.FechaFinPoliza,
                    NombrePlanPoliza = poliza.NombrePlanPoliza,
                    ValorMaximoCubierto = poliza.ValorMaximoCubierto
                };

                seguroContext.Add(data);
                seguroContext.SaveChanges();

                return data;
            }            
        }
    }
}
