using Curso.Biblioteca.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Dominio.Repositorios
{
    public interface ILibroRepository
    {
        IQueryable<Libro> GetAllAsync();
        Task CreateAsync(Libro entity);
        Task UpdateAsync(Libro entity);
        Task DeleteAsync(Libro entity);
    }
}
