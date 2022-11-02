using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase, IAutorAppService
    {
        private readonly IAutorAppService autorAppService;

        public AutorController(IAutorAppService autorAppService)
        {
            this.autorAppService = autorAppService;
        }

        [HttpPost]
        public async Task CreateAsync(CrearAutorDto autorDto)
        {
            await autorAppService.CreateAsync(autorDto);
        }

        [HttpDelete]
        public async Task DeleteAsync(int id)
        {
            await autorAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            return await autorAppService.GetAllAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(int id, ActualizarAutorDto autorDto)
        {
            await autorAppService.UpdateAsync(id, autorDto);
        }
    }
}
