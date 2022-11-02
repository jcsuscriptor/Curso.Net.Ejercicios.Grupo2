using Curso.Biblioteca.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Infraestructura.ConfiguracionEntidades
{
    public class LibroConfiguracion : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libros");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
            .IsRequired();

            builder.Property(b => b.Titulo)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(b => b.ISBN)
            .HasMaxLength(25)
            .IsRequired();

            builder.HasOne(b => b.Autor)
                .WithMany()
                .HasForeignKey(b => b.AutorId);

            builder.HasOne(b => b.Editorial)
                .WithMany()
                .HasForeignKey(b => b.EditorialId);
        }
    }
}
