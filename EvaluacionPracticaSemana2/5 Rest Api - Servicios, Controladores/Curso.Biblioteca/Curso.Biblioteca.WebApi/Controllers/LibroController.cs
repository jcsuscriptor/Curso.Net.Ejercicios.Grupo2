using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase, ILibroAppService
    {
        private readonly ILibroAppService libroAppService;

        public LibroController(ILibroAppService libroAppService)
        {
            this.libroAppService = libroAppService;
        }

        [HttpPost]
        public async Task CreateAsync(CrearLibroDto libroDto)
        {
            await libroAppService.CreateAsync(libroDto);
        }

        [HttpDelete]
        public async Task DeleteAsync(int id)
        {
            await libroAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            return await libroAppService.GetAllAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(int id, ActualizarLibroDto libroDto)
        {
            await libroAppService.UpdateAsync(id, libroDto);
        }
    }
}
