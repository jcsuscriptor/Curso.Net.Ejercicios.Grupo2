using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryStringController : ControllerBase
    {


        /// <summary>
        /// Model Binding => Query String. 
        /// Parametro Name, LastName =>   ?name=valueName&lastName=valueLastName
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetName(string name,string lastName) {

            return $"{name} {lastName}";
        }


        [HttpGet("~/curso/routes{valorA}")]
        public int Sum([FromRoute(Name="valorA")]int valorA)
        {
            return valorA;
        }


        [HttpGet("hi")]
        public string Hi()
        {
            return "hello";
        }


    }
}
