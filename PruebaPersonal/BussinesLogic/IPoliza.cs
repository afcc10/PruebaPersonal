using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System.Net.Http;

namespace PruebaPersonal.BussinesLogic
{
    public interface IPoliza
    {
        PolizaModels Crear(PolizaDto poliza);
    }
}
