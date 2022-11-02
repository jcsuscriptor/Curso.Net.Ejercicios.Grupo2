using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios
{
    public interface ILibroAppService
    {
        Task<ICollection<LibroDto>> GetAllAsync();
        Task CreateAsync(CrearLibroDto libroDto);
        Task UpdateAsync(int id, ActualizarLibroDto libroDto);
        Task DeleteAsync(int id);
    }
}
