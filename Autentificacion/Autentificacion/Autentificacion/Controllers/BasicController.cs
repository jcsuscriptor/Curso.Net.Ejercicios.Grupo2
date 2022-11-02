using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Autentificacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {

        [HttpPost]
        public bool Autentificar()
        {

            //Recuperar valor de las cabecera Authorization
            string authHeader = Request.Headers["Authorization"];
            if (authHeader == null)
            {
                return false;   
            }

            //Separar valores
            string auth = authHeader.Split(new char[] { ' ' })[1];
            var encoding = Encoding.GetEncoding("UTF-8");
            
            //Los valores se encuentran en Base64
            var usernameAndPassword = encoding.GetString(Convert.FromBase64String(auth));
            
            //Separar los valores usuario y clave
            string username = usernameAndPassword.Split(new char[] { ':' })[0];
            string password = usernameAndPassword.Split(new char[] { ':' })[1];

            //Verificar valores
            if (username == "foo" && password == "123")
            {
                return true;
            }

            return false;

        }
    }
}
