using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaPersonal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PruebaPersonal.Data.Dao
{
    public class PolizaDao : ContextBase, IPolizaDao
    {   

        public IEnumerable<PolizaModels> ConsultaPolizaxPlacaoNumero(string numeroPoliza, string placa)
        {
            GetContexto();
            using (_context)
            {
                return _context.ConsultaPolizaxPlacaoNumero(numeroPoliza, placa);
            }            
        }

        public bool CrearPoliza(PolizaModels data)
        {
            GetContexto();
            using (_context)
            {
                try
                {
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {                    
                    throw ex.InnerException;                    
                }
            }
        }

        public bool CrearPolizaCoberturas(PolizaCoberturasModels data)
        {
            GetContexto();
            using (_context)
            {
                try
                {
                    _context.Add(data);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {

                    throw ex.InnerException;
                }
            }
        }

        public ClienteModels GetClientesByNumeroIdentificacionCliente(string numeroIdentificacionCliente)
        {
            ClienteModels clienteModels = new();
            GetContexto();
            using (_context)
            {
                 clienteModels = _context.ClientesModels
                                        .Where(x => x.IdentificacionCliente.Equals(numeroIdentificacionCliente))
                                        .FirstOrDefault();
            }

            return clienteModels;
        }

        public CoberturaPolizaModels GetCoberturaPolizaModelsById(string IdCobertura)
        {
            CoberturaPolizaModels coberturaPolizaModels = new();

            GetContexto();
            using (_context)
            {

                coberturaPolizaModels = _context.CoberturasPolizaModels
                                                    .Where(x => x.Id == Guid.Parse(IdCobertura))
                                                    .FirstOrDefault();
            }

            return coberturaPolizaModels;
        }

        public string GetNumeroPolizaByFechasAndIdCliente(string IdCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            string numeroPoliza;
            GetContexto();
            using (_context)
            {
                numeroPoliza = _context.PolizasModels
                                                .Where(x => x.ClienteIdentificacionCliente.Equals(IdCliente)
                                                    && ((x.FechaInicioPoliza.Date >= fechaInicio.Date && x.FechaFinPoliza.Date <= fechaInicio.Date) ||
                                                    x.FechaInicioPoliza.Date >= fechaFin.Date && x.FechaFinPoliza.Date <= fechaFin.Date))
                                        .Select(x => x.NumeroPoliza).FirstOrDefault();
            }

            return numeroPoliza;
        }
    }
}
