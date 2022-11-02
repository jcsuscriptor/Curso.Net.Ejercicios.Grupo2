using Curso.Biblioteca.Dominio.Entidades;
using Curso.Biblioteca.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.Repositorios
{
    public class LibroRepository : ILibroRepository
    {
        private readonly BibliotecaDbContext context;

        public LibroRepository(BibliotecaDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Libro entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Libro entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public IQueryable<Libro> GetAllAsync()
        {
            return context.Libros.AsQueryable();
        }

        public async Task UpdateAsync(Libro entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
