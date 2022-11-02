using Curso.Biblioteca.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Curso.Biblioteca.Aplicacion.Dtos
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }

        public string ISBN { get; set; }

        public DateTime? Publicacion { get; set; }


        public string? Genero { get; set; }


        public long? Cantidad { get; set; }

        public string Autor { get; set; }
        public string Editorial { get; set; }

        public int AutorId { get; set; }

        public int EditorialId { get; set; }


    }




}