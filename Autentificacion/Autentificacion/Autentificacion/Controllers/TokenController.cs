using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Autentificacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase {

        private readonly JwtConfiguration jwtConfiguration;


        public TokenController(IOptions<JwtConfiguration> options) {
            this.jwtConfiguration = options.Value;
        }


        [HttpPost]
        public async Task<string> TokenAsync(UserInput input)
        {
            var usuarios = new [] {
                new { Usr= "foo",Roles=new[] { "Admin" } },
                new { Usr= "bar",Roles=new[] { "Consulta", "Soporte" } },
                new { Usr= "user",Roles=new[] { "Contabilidad","Facturacion" } },
            };

            //1. Validar User.
            if (!usuarios.Any(u => u.Usr.Equals(input.UserName)) || input.Password != "123")
            {
                throw new AuthenticationException("User or Passowrd incorrect!");
            }
             
            //2. Generar claims
            //create claims details based on the user information
            var claims = new List<Claim>();

            var user = usuarios.Single(u => u.Usr.Equals(input.UserName));

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Usr));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()));
            claims.Add(new Claim("UserName", input.UserName));
           
            //Roles
            foreach (var item in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item)); 
            }

            claims.Add(new Claim("TieneLicencia", true.ToString()));
            claims.Add(new Claim("Ecuatoriano", true.ToString()));
            claims.Add(new Claim("Seguro", "Foo123"));
             

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                claims,
                expires: DateTime.UtcNow.Add(jwtConfiguration.Expires),
                signingCredentials: signIn);
 

           var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


            return jwt;
        }

        
    }

    public class UserInput
    {

        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
