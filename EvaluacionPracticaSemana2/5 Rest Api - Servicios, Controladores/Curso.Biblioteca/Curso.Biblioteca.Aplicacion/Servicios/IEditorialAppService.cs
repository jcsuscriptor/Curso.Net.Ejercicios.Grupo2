using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios
{
    public interface IEditorialAppService
    {
        Task<ICollection<EditorialDto>> GetAllAsync();
        Task CreateAsync(CrearEditorialDto editorialDto);
        Task UpdateAsync(int id, ActualizarEditorialDto editorialDto);
        Task DeleteAsync(int id);
    }
}
