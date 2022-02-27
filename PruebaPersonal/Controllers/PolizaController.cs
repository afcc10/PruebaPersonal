using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PruebaPersonal.BussinesLogic;
using PruebaPersonal.Data;
using PruebaPersonal.Helpers;
using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System;
using System.Net;
using System.Runtime.InteropServices;

namespace PruebaPersonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PolizaController : ControllerBase
    {
        private readonly ILogger<PolizaController> _logger;
        private readonly IPoliza poliza = null;
        private readonly SeguroContext seguroContext;
        private readonly IConfiguration _config;

        public PolizaController(ILogger<PolizaController> logger, SeguroContext seguroContext, IConfiguration config)
        {
            _logger = logger;
            this.poliza = new Poliza(seguroContext);
            this._config = config;
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<object> CrearToken([FromBody] PersonaDto persona)
        {
            var secret = this._config.GetValue<string>("Secret");
            var jwtHelper = new JWTHelper(secret);
            var token = jwtHelper.createToken(persona.Usuario);

            return Ok(new
            {
                Ok = true,
                msg = "Token creado con exito",
                token
            });
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Post([FromBody] PolizaDto resquet)
        {
            PolizaModels model = poliza.Crear(resquet);

            if (model != null)
            {
                return new OkObjectResult (new {status = HttpStatusCode.OK, data = model });
            }
            else
            {
                
                return new OkObjectResult(new { status = HttpStatusCode.BadRequest, 
                                                message = "Error de datos o el usuario ya tiene una poliza en el rango de fechas enviado" });
            }            
        }

        
        [HttpGet()]
        public IActionResult Get([Optional] string numeroPoliza, [Optional]  string placa)
        {
            var model = poliza.ConsultaPolizas(numeroPoliza, placa);

            if (model != null)
            {
                return new OkObjectResult(new { status = HttpStatusCode.OK, data = model });
            }
            else
            {
                return new OkObjectResult(new { status = HttpStatusCode.BadRequest, 
                                                message = "No se encontraron resultados" });
            }
           
        }
    }
}
