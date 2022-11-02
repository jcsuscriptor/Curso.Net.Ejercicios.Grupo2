using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBinding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        [HttpPost("{billId}")]
        public bool Anular(string billId) {
            return true;
        }


        [HttpPut("{billId}")]
        public bool ChanceStatus(string billId,string status)
        {
            Console.WriteLine($"billId: {billId} status: {status}");
            return true;
        }
    }
}
