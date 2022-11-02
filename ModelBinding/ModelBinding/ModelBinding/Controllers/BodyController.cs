using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyController : ControllerBase
    {

        [HttpPost]
        public string Procesar(Client client)
        {

            return client.ToString();
        }


        [HttpPut]
        public string Actualizar(Client client)
        {

            return client.ToString();
        }

         
    }

    public class Product
    {

        public string Name { get; set; }

        public string Code { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Name} Code: {Code}";
        }
    }

    public class Client
    {

        public string? Name { get; set; }

        public string? Phone { get; set; }


        public int Age { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Name} Edad: {Age} Telenfo: {Phone}";
        }

    }
}
