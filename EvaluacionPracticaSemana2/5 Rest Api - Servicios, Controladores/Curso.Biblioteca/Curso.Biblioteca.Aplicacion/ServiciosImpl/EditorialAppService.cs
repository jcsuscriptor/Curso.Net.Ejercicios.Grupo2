using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Aplicacion.Servicios;
using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.ServiciosImpl
{
    public class EditorialAppService : IEditorialAppService
    {
        private readonly IEditorialRepository editorialRepository;

        public EditorialAppService(IEditorialRepository editorialRepository)
        {
            this.editorialRepository = editorialRepository;
        }

        public async Task CreateAsync(CrearEditorialDto editorialDto)
        {
            var entity = new Editorial {
                    Nombre = editorialDto.Nombre,
                    Direccion = editorialDto.Direccion
                };
            await editorialRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var lista = await editorialRepository.GetAllAsync();
            var entity = lista.Where(x => x.Id == id).SingleOrDefault();
            await editorialRepository.DeleteAsync(entity);
        }

        public async Task<ICollection<EditorialDto>> GetAllAsync()
        {
            var lista = await editorialRepository.GetAllAsync();
            return lista.Select(x => new EditorialDto {
                Id = x.Id,
                Nombre = x.Nombre,
                Direccion = x.Direccion
            }).ToList();
        }

        public async Task UpdateAsync(int id, ActualizarEditorialDto editorialDto)
        {
            var lista = await editorialRepository.GetAllAsync();
            var entity = lista.Where(x => x.Id == id).SingleOrDefault();

            entity.Nombre = editorialDto.Nombre;
            entity.Direccion = editorialDto.Direccion;

            await editorialRepository.UpdateAsync(entity);
        }
    }
}
