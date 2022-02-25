using System.ComponentModel.DataAnnotations;

namespace PruebaPersonal.Models
{
    public class AutomotorModels
    {
        [Key]
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public bool TieneInspeccion { get; set; }
    }
}
