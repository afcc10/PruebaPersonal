using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaPersonal.Helpers;
using PruebaPersonal.Models.Dtos;


namespace PruebaPersonal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
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
    }
}
