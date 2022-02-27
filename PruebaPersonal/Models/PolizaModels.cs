using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PruebaPersonal.Models
{
    public class PolizaModels
    {
        [Key]
        [Required]
        public string NumeroPoliza { get; set; }
        public DateTime FechaInicioPoliza { get; set; }
        public DateTime FechaFinPoliza { get; set; }       
        public double ValorMaximoCubierto { get; set; }
        public string NombrePlanPoliza { get; set; } 
        public string ClienteIdentificacionCliente { get; set; }
        public virtual ClienteModels Cliente { get; set; }            
    }
}
