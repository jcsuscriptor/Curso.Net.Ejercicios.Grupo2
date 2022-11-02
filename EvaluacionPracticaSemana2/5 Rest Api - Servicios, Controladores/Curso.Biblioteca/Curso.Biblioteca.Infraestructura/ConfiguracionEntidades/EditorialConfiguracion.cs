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
    public class EditorialConfiguracion : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("Editoriales");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
            .IsRequired();

            builder.Property(b => b.Nombre)
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(b => b.Direccion)
            .HasMaxLength(256)
            .IsRequired();
        }
    }
}
