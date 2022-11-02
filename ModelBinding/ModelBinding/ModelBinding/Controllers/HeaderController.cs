using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {

        [HttpGet]
        public string Procesar([FromHeader] string name, [FromHeader] string code) {

            return $"Name {name}, code {code}";
        }
    }
}
