using Curso.Biblioteca.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Curso.Biblioteca.Aplicacion.Dtos
{
    public class ActualizarLibroDto
    {
        [Required]
        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Titulo { get; set; }

        public string ISBN { get; set; }

        [StringLength(DominioConstantes.DESCRIPCION_MAXIMO)]
        public string? Descripcion { get; set; }

        [Required]
        public int AutorId { get; set; }

        [Required]
        public int EditorialId { get; set; }


        public DateTime? Publicacion { get; set; }

        public string? Genero { get; set; }


        public long? Cantidad { get; set; }

    }
}