using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasico
{

    public class Persona
    {

        public string Nombre { get; set; }

        public Sexo Sexo { get; set; }

        public string CuidadNacimiento { get; set; }

        public int Edad { get; set; }
    }

    public enum Sexo
    {
        Masculino,
        Femenino
    }



    public class Cliente
    {

        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public bool Activo { get; set; }

        public int Edad { get; set; }

        public string CategoriaCodigo { get; set; }

        public ClienteTipo Tipo { get; set; } = ClienteTipo.Bronce;

        public override string ToString()
        {
            return $"Nombre: {Nombre}. Codigo: {Codigo}. Edad: {Edad}. Tipo: {Tipo}";
        }

    }


    public class Categoria {
        public string Codigo { get; set; }

        public string Nombre { get; set; } 

    }

    public enum ClienteTipo
    {

        Oro,
        Plata,
        Bronce
    }

    public class ClienteDto
    {

        public string Nombre { get; set; }

        public string Codigo { get; set; }

    }

    public class Venta
    {

        public DateTime Fecha { get; set; }

        public decimal Valor { get; set; }

        public string ClienteCodigo { get; set; }

    }
}
