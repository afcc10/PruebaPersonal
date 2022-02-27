using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System.Collections.Generic;
using System.Net.Http;

namespace PruebaPersonal.BussinesLogic
{
    public interface IPoliza
    {
        PolizaModels Crear(PolizaDto poliza);

        IEnumerable<PolizaModels> ConsultaPolizas(string numeroPoliza,string placa);
    }
}
