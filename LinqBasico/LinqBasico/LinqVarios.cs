namespace LinqBasico
{
    public static class LinqVarios
    {


        public static void DuplicadosVisualizar() {

            var nombres = new string[] { "Uno", "Dos", "Dos" };


            var consulta = from nombre in nombres
                           group nombre by nombre into grupo
                           where
                             //Sql: Having (*)
                             grupo.Count() > 1
                           select grupo
                           ;

            
            
        
        }

        public static void Single() {

            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false },
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true },
                new Cliente{ Codigo = "C4", Nombre="Roberto" }
            };

            var consulta = from cliente in clientes
                           select cliente;

            consulta = consulta.Where(c => c.Codigo == "C4");

            var clienteBuscador = consulta.SingleOrDefault();

            var clienteX = consulta.First();

            var clienteY = consulta.Last();

        }

        /// <summary>
        /// LINQ – Operadores de particionado
        /// </summary>
        public static void OperadoresParticionado()
        {

            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false },
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true },
                new Cliente{ Codigo = "C4", Nombre="Roberto" },
                new Cliente{ Nombre="ANGEL" },
                new Cliente{ Nombre="Juan" },
                new Cliente{ Nombre="Carmen" }
            };


            var elementosSaltar = 2;
            var elementosRecuperar = 2;
            var consulta = clientes.Skip(elementosSaltar).Take(elementosRecuperar);

            foreach (var item in consulta)
            {
                Console.WriteLine($"Nombre: {item.Nombre}. Codiog {item.Codigo}. Activo {item.Activo}");

            }
        }

        /// <summary>
        /// All – Todos los elementos
        /// Any – Uno o varios elementos
        // Contains
        /// </summary>
        public static void OperadoresCuantificacion()
        {

            //Retorna true/falso
            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false },
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true },
                new Cliente{ Codigo = "C4", Nombre="Roberto" },
                new Cliente{ Nombre="ANGEL" },
            };

            //All
            var resultadoTodosCumple = clientes.All(a => a.Nombre.Count() > 6);

            Console.WriteLine($"ResultadoTodosCumple: {resultadoTodosCumple}");

            //Any. (Alguno).
            //select nombres,codigos clientes where exist (select * from clientesVentas)
            var resultadoAlgunoCumple = clientes.Any(a => a.Nombre.ToLower() == "luis");

            Console.WriteLine($"resultadoAlgunoCumple: {resultadoAlgunoCumple}");

            //Contains
            //var resultadoContiene = clientes.Where(a => clientes.Contains(new Cliente { Nombre }));
            var colores = new string[] { "amarillo", "negro", "amarillo", "blanco", "rojo", "Amarillo" };
            //var coloresResultado = colores.Where(a => colores.Contains("verde"));

            if (colores.Contains("verde"))
            {
                Console.WriteLine("SI contiene");
            }

            //Any => contains
            if (colores.Any(a => a == "verde"))
            {
                Console.WriteLine("SI contiene");
            }

            //Console.WriteLine($"resultadoContiene: {resultadoContiene}"); 
            //foreach (var item in coloresResultado)
            //{
            //    Console.WriteLine(item);
            //}
        }

    }

}



