using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaPersonal.BussinesLogic;
using PruebaPersonal.Data;
using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace PruebaPersonal.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
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

        [Microsoft.AspNetCore.Mvc.Route("[action]")]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult Post(PolizaDto resquet)
        {           

            PolizaModels model = poliza.Crear(resquet);

            if (model != null)
            {
                return new OkObjectResult (new {status = HttpStatusCode.OK, data = model });
            }
            else
            {
                return new OkObjectResult(new { status = HttpStatusCode.BadRequest });
            }            
        }        
    }
}
