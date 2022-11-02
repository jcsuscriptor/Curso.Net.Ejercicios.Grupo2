using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase, IEditorialAppService
    {
        private readonly IEditorialAppService editorialAppService;

        public EditorialController(IEditorialAppService editorialAppService)
        {
            this.editorialAppService = editorialAppService;
        }

        [HttpPost]
        public async Task CreateAsync(CrearEditorialDto editorialDto)
        {
            await editorialAppService.CreateAsync(editorialDto);
        }

        [HttpDelete]
        public async Task DeleteAsync(int id)
        {
            await editorialAppService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            return await editorialAppService.GetAllAsync();
        }

        [HttpPut]
        public async Task UpdateAsync(int id, ActualizarEditorialDto editorialDto)
        {
            await editorialAppService.UpdateAsync(id, editorialDto);
        }
    }
}
