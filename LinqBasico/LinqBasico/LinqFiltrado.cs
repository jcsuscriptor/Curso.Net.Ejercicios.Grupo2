namespace LinqBasico
{
    public static class LinqFiltrado
    {
        public static void Where()
        {

            //Filtros
            //Sql:  Where
            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false },
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true },
                new Cliente{ Codigo = "C4", Nombre="Roberto" },
                new Cliente{ Nombre="ANGEL" },
            };


            // SQL:
            // proyeccion => campos que requiero
            // select nombre,codigo from clientes
            var consulta = from cliente in clientes
                               //Filtro
                           where
                              cliente.Activo
                           //Proyeccion => Objeto. 
                           select cliente;


            var clientesDto = from cliente in clientes
                                  //Filtro
                              where
                                 cliente.Nombre.ToLower() == "luis"
                                 || cliente.Nombre.ToUpper() == "MARIA"
                              //Proyeccion => Nuevo Objeto Tipiado
                              select new ClienteDto() { Codigo = cliente.Codigo, Nombre = cliente.Nombre };



            var clientesCodigos = from cliente in clientes
                                      //Filtro
                                  where
                                     cliente.Nombre.ToUpper().StartsWith("A")
                                  //Proyeccion => Propiedad. 
                                  select cliente.Codigo;


            var clientesCodigosNombres = from cliente in clientes
                                             //Filtro
                                         where
                                            cliente.Activo && cliente.Nombre.Count() > 3
                                         //Proyeccion => Nuevo Objeto Dinamico
                                         select new { cliente.Codigo, cliente.Nombre };




            var consultaFluent = clientes.Where(a => a.Activo);


            foreach (var item in consulta)
            {
                Console.WriteLine($"Nombre: {item.Nombre}. Codiog {item.Codigo}. Activo {item.Activo}");

            }

        }

    }

}



