using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }

        public DbSet<Editorial> Editoriales { get; set; }

        public DbSet<Libro> Libros { get; set; }

        public BibliotecaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
