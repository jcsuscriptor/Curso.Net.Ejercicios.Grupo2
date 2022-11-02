using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {

        [HttpPost]
        public string Procesar([FromForm] Product product)
        {
            return $"Producto: {product}.";
        }
    }
}
