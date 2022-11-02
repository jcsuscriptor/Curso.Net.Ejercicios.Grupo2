using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {

        [HttpGet("status/{value:int}/active/{active}")]
        public string Status(int value,bool active) {

            if (active)
            {
                switch (value)
                {
                    case 0:
                        return "Status Stop";
                    case 1:
                        return "Status Starting";
                    case 2:
                        return "Status Finish";
                    default:
                        return "Status not soport";
                }
            }
            else {

                return "Without Data";
            }
             
        }

        [HttpPut("{status}")]
        public string Status(string status) {

            return status;
        }


        [HttpPut("example/{information}")]
        public string ExampleTwo(string information)
        {

            return $"Este valor es binding con route. Valor de variable information configurada en la ruta {information}";
        }



    }

   
}
