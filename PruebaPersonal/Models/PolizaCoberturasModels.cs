﻿using System;

namespace PruebaPersonal.Models
{
    public class PolizaCoberturasModels
    {
        public Guid Id { get; set; }
        public virtual PolizaModels poliza { get; set; }
        public virtual CoberturaPolizaModels Cobertura { get; set; }
    }
}
