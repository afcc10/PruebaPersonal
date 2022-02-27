using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PruebaPersonal.BussinesLogic;
using PruebaPersonal.Data;
using PruebaPersonal.Data.Dao;
using PruebaPersonal.Helpers;
using PruebaPersonal.Models;
using PruebaPersonal.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Runtime.InteropServices;

namespace PruebaPersonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PolizaController : ControllerBase
    {        
        private readonly IPoliza poliza = null;   

        public PolizaController()
        {           
            IPolizaDao polizaDao = new PolizaDao();
            this.poliza = new Poliza(polizaDao);            
        }        

        [Route("[action]")]
        [HttpPost]
        public IActionResult Post([FromBody] PolizaDto resquet)
        {
            PolizaModels model = poliza.Crear(resquet);

            if (model != null)
            {
                return new OkObjectResult (new ApiResponse { status = HttpStatusCode.OK, poliza = model });
            }
            else
            {
                
                return new OkObjectResult(new ApiResponse { status = HttpStatusCode.BadRequest, 
                                                Message = "Error de datos o el usuario ya tiene una poliza en el rango de fechas enviado" });
            }            
        }

        
        [HttpGet()]
        public IActionResult Get([Optional] string numeroPoliza, [Optional]  string placa)
        {
            var model = poliza.ConsultaPolizas(numeroPoliza, placa);

            if (IsIENumerableLleno(model))
            {
                return new OkObjectResult(new ApiResponse { status = HttpStatusCode.OK, data = model });
            }
            else
            {
                return new OkObjectResult(new ApiResponse { status = HttpStatusCode.BadRequest,
                                                            Message = "No se encontraron resultados" });
            }

        }  
	
        private bool IsIENumerableLleno(IEnumerable<PolizaModels> ieNumerable)
        {
            bool isFull = false;
            foreach (PolizaModels item in ieNumerable)
            {
                isFull = true;
                break;
            }
            return isFull;
        }
    }
}
