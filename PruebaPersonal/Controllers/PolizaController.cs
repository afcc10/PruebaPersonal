using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaPersonal.BussinesLogic;
using PruebaPersonal.Data;
using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;

namespace PruebaPersonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolizaController : ControllerBase
    {       
        private readonly ILogger<PolizaController> _logger;
        private readonly IPoliza poliza = null;
        private readonly SeguroContext seguroContext;

        public PolizaController(ILogger<PolizaController> logger, SeguroContext seguroContext)
        {
            _logger = logger;
            this.poliza = new Poliza(seguroContext);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Post(PolizaDto resquet)
        {           

            PolizaModels model = poliza.Crear(resquet);

            if (model != null)
            {
                return new OkObjectResult (new {status = HttpStatusCode.OK, data = model });
            }
            else
            {
                
                return new OkObjectResult(new { status = HttpStatusCode.BadRequest, message = "Error de datos o el usuario ya tiene una poliza en el rango de fechas enviado" });
            }            
        }

        
        [HttpGet()]
        public IActionResult Get([Optional] string numeroPoliza, [Optional]  string placa)
        {
            var model = poliza.ConsultaPolizas(numeroPoliza, placa);


            return new OkObjectResult(new { status = HttpStatusCode.OK, data = model });
        }
    }
}
