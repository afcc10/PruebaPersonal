using PruebaPersonal.Models;
using System;
using System.Collections.Generic;

namespace PruebaPersonal.Data.Dao
{
    public interface IPolizaDao
    {
        public IEnumerable<PolizaModels> ConsultaPolizaxPlacaoNumero(string numeroPoliza, string placa);

        public ClienteModels GetClientesByNumeroIdentificacionCliente(string numeroIdentificacionCliente);

        public CoberturaPolizaModels GetCoberturaPolizaModelsById(string IdCobertura);

        public string GetNumeroPolizaByFechasAndIdCliente(string IdCliente, DateTime fechaInicio, DateTime fechaFin);

        public bool CrearPoliza(PolizaModels data);
        public bool CrearPolizaCoberturas(PolizaCoberturasModels data);
    }
}
