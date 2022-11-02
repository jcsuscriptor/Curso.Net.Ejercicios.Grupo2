using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Biblioteca.Dominio.Entidades
{
    public class Libro
    {
        [Required]
        public int Id { get; set; }

        [StringLength(DominioConstantes.NOMBRE_MAXIMO)]
        public string Titulo { get; set; }

        
        [StringLength(DominioConstantes.DESCRIPCION_MAXIMO)]
        public string? Descripcion { get; set; }


        public string ISBN { get; set; }

        public DateTime? Publicacion { get; set; }


        public string? Genero { get; set; }


        public long? Cantidad { get; set; }


        [Required]
        public int AutorId { get; set; }
        
        public Autor Autor { get; set; }

        [Required]
        public int EditorialId { get; set; }
        
        public Editorial Editorial { get; set; }

    }
}
