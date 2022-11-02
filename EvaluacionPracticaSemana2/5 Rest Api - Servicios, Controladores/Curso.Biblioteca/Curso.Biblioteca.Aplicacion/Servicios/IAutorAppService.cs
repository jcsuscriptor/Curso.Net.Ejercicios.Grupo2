using Curso.Biblioteca.Aplicacion.Dtos;
using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Aplicacion.Servicios
{
    public interface IAutorAppService
    {
        Task<ICollection<AutorDto>> GetAllAsync();
        Task CreateAsync(CrearAutorDto autorDto);
        Task UpdateAsync(int id, ActualizarAutorDto autorDto);
        Task DeleteAsync(int id);
    }
}
