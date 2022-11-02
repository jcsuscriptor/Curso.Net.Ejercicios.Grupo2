using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configuraciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : ControllerBase
    {
        private readonly ConfiguracionAutentificacion configuracionAutentificacion;
        private readonly IConfiguration configuration;


        /// <summary>
        /// 1. Inyectar.
        /// Inyectar con IOptions<Type>
        /// </summary>
        /// <param name="configuracionAutentificacion"></param>
        public ConfiguracionController(IOptions<ConfiguracionAutentificacion> configuracionAutentificacion,
            IConfiguration configuration) {

            //IOptins. propieaad Value, retorna el objeto configurado. 
            this.configuracionAutentificacion = configuracionAutentificacion.Value;
            this.configuration = configuration;
        }

        [HttpGet]
        public string GetWithOption() {

            return configuracionAutentificacion.Key;
        }



        [HttpGet("get-with-key")]
        public string GetWithKey()
        {
            return configuration["ConfigurationAuth:Key"];
        }

    }
}
