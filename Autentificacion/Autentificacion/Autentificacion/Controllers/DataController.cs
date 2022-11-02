using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Claims;

namespace Autentificacion
{
    //3. Establecer los api que requiere usuario autentificado
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DataController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }


        
        [HttpGet]
        public string GetValue() {

            return "Informacion autorizada";
        }

        [AllowAnonymous]
        [HttpGet("user-info")]
        public List<string> GetUser()
        {
            var user = httpContextAccessor.HttpContext?.User;
 
            if (user == null || !(user.Identity?.IsAuthenticated??false))
                throw new AuthenticationException("Usuario no autentificado!");


            var claims = user.Claims
                    .Select(a => $"{a.Type}: {a.Value}").ToList();

            return claims;
        }

        [Authorize(Roles = "Admin,Facturacion")]
        [HttpGet("permiso-roles")]
        public string GetRoles()
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null || !(user.Identity?.IsAuthenticated ?? false))
                throw new AuthenticationException("Usuario no autentificado!");


            var claimRoles = user.Claims
                    .Where(mc => mc.Type.Equals(ClaimTypes.Role))
                    .Select(mc => mc.Value);

            return string.Join(",", claimRoles);
        }


        //2. Aplicar la politica 
        [Authorize(Policy = "PolicyComplex")]
        [HttpGet("verificar-claim")]
        public List<string> GetClaim()
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null || !(user.Identity?.IsAuthenticated ?? false))
                throw new AuthenticationException("Usuario no autentificado!");


            var claims = user.Claims
                    .Select(a => $"{a.Type}: {a.Value}").ToList();

            return claims;
        }

    }
}
