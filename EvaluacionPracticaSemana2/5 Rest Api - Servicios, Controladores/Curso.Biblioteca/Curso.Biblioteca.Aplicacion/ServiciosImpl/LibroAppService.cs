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
    public class LibroAppService : ILibroAppService
    {
        private readonly ILibroRepository libroRepository;

        public LibroAppService(ILibroRepository libroRepository)
        {
            this.libroRepository = libroRepository;
        }

        public async Task CreateAsync(CrearLibroDto libroDto)
        {
            var entity = new Libro {
                    Titulo = libroDto.Titulo,
                    ISBN = libroDto.ISBN,
                    AutorId = libroDto.AutorId,
                    EditorialId = libroDto.EditorialId,
                    Descripcion = libroDto.Descripcion,
                Cantidad = libroDto.Cantidad,
                Publicacion = libroDto.Publicacion,
                Genero = libroDto.Genero,
            };
            await libroRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var query = libroRepository.GetAllAsync();
            query = query.Where(x => x.Id == id);
            var entity = query.SingleOrDefault();
            await libroRepository.DeleteAsync(entity);
        }

        public async Task<ICollection<LibroDto>> GetAllAsync()
        {
            var query = libroRepository.GetAllAsync();
            return query.Select(x => new LibroDto {
                Id = x.Id,
                Titulo = x.Titulo,
                ISBN = x.ISBN,
                Autor = $"{x.Autor.Nombre} {x.Autor.Apellido}",
                AutorId =x.AutorId,
                EditorialId = x.EditorialId,
                Cantidad = x.Cantidad,
                Descripcion = x.Descripcion,
                Genero = x.Genero,
                Publicacion = x.Publicacion,
                Editorial = x.Editorial.Nombre
            }).ToList();
        }

        public async Task UpdateAsync(int id, ActualizarLibroDto libroDto)
        {
            var query = libroRepository.GetAllAsync();
            query = query.Where(x => x.Id == id);
            var entity = query.SingleOrDefault();

            entity.Titulo = libroDto.Titulo;
           
            entity.ISBN = libroDto.ISBN;
            entity.AutorId = libroDto.AutorId;
            entity.EditorialId = libroDto.EditorialId;
            entity.Descripcion = libroDto.Descripcion;
            entity.Cantidad = libroDto.Cantidad;
            entity.Publicacion = libroDto.Publicacion;
            entity.Genero = libroDto.Genero;

            await libroRepository.UpdateAsync(entity);
        }
    }
}
