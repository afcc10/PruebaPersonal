using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaPersonal.Models
{
    public class CoberturaPolizaModels
    {
        [Key]
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
    }
}
