using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombinadoController : ControllerBase
    {

        [HttpPost("process/{elementId}")]
        public string Procesar(string elementId, [FromBody] Product product, [FromHeader] string token, [FromQuery(Name = "estado")] string status) {

            return $"ElementId {elementId}. Producto: {product}. Token {token}. Status {status}";
        }

        [HttpDelete]
        public string DeleteWithBody([FromBody] Product product)
        {
            return $"Producto: {product}.";
        }


       
    }
}
