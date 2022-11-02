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
    public class AutorAppService : IAutorAppService
    {
        private readonly IAutorRepository autorRepository;

        public AutorAppService(IAutorRepository autorRepository)
        {
            this.autorRepository = autorRepository;
        }

        public async Task CreateAsync(CrearAutorDto autorDto)
        {
            var entity = new Autor {
                    Nombre = autorDto.Nombre,
                    Apellido = autorDto.Apellido
                };
            await autorRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var lista = await autorRepository.GetAllAsync();
            var entity = lista.Where(x => x.Id == id).SingleOrDefault();
            await autorRepository.DeleteAsync(entity);
        }

        public async Task<ICollection<AutorDto>> GetAllAsync()
        {
            var lista = await autorRepository.GetAllAsync();
            return lista.Select(x => new AutorDto {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido
            }).ToList();
        }

        public async Task UpdateAsync(int id, ActualizarAutorDto autorDto)
        {
            var lista = await autorRepository.GetAllAsync();
            var entity = lista.Where(x => x.Id == id).SingleOrDefault();

            entity.Nombre = autorDto.Nombre;
            entity.Apellido = autorDto.Apellido;

            await autorRepository.UpdateAsync(entity);
        }
    }
}
