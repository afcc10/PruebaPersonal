using System;

namespace PruebaPersonal.Models.Dtos
{
    public class PolizaDto
    {
        public string NumeroPoliza { get; set; }
        public DateTime FechaInicioPoliza { get; set; }
        public DateTime FechaFinPoliza { get; set; }
        public string IdCobertura { get; set; }
        public double ValorMaximoCubierto { get; set; }
        public string NombrePlanPoliza { get; set; }
        public string NumeroidentificacionCliente { get; set; }

    }
}
