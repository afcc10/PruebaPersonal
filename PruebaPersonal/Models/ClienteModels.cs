using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaPersonal.Models
{
    public class ClienteModels
    {
        [Key]
        public string IdentificacionCliente { get; set; }

        public string NombreCliente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadResidencia { get; set; }
        public string DireccionResidencia { get; set; }
        public virtual AutomotorModels Automotor { get; set; }
    }
}
