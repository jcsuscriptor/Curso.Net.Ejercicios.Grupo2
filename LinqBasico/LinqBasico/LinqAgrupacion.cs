namespace LinqBasico
{
    public static class LinqAgrupacion {


        public static void CombinacionVarios() {

            var categorias = new Categoria[] {
                new Categoria{ Codigo = "001", Nombre="Categoria A" },
                new Categoria{ Codigo = "002", Nombre="Categoria B"  }
            };

            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true, CategoriaCodigo = "001" },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false, CategoriaCodigo = "001" },
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true, CategoriaCodigo = "002" },
                new Cliente{ Codigo = "C4", Nombre="Roberto", CategoriaCodigo = "001" } 
            };

            var ventas = new Venta[] {
                new Venta { Fecha = DateTime.Now.AddYears(1),Valor = 100M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(-3),Valor = 78.3M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(-2),Valor = 103M, ClienteCodigo = "C4"},
                new Venta { Fecha = DateTime.Now.AddYears(-4),Valor = 28M, ClienteCodigo = "C1"},
            };

            var consulta = from cliente in clientes
                           //1. Combinacion
                           join venta in ventas
                           on cliente.Codigo equals venta.ClienteCodigo
                           //2. Combinacion
                           join categoria in categorias
                           on cliente.CategoriaCodigo equals categoria.Codigo
                           //Proyeccion
                           select new { Categoria = categoria.Nombre, Nombre = cliente.Nombre, ValorVenta = venta.Valor }
                           ;

            consulta.ToList().ForEach(item =>
            {
                Console.WriteLine($"Categoria {item.Categoria}. Cliente {item.Nombre}. Venta {item.ValorVenta}");
            });


        }


        public static void Join()
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

            var ventas = new Venta[] {
                new Venta { Fecha = DateTime.Now.AddYears(1),Valor = 10.000M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(0),Valor = 7000M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(4),Valor = 103M, ClienteCodigo = "C4"},
                new Venta { Fecha = DateTime.Now.AddYears(5),Valor = 28M, ClienteCodigo = "C1"},
            };

            //select cli.nombre,cliVen.Valor from clientes cli inner join clienteVentas cliVen on cli.codigo = cliVen.clienteCodigo 
            //Sql: inner join
            var consulta = from cliente in clientes
                           join venta in ventas
                           on cliente.Codigo equals venta.ClienteCodigo
                           select new { Nombre = cliente.Nombre, Valor = venta.Valor }
                        ;



            var consultaMetodo = clientes.Join(ventas,
                    cliente => cliente.Codigo,
                    venta => venta.ClienteCodigo,
                    (cliente, venta) => new { Nombre = cliente.Nombre, Valor = venta.Valor });



            // var consulta = clientes.Join(clienteVentas,a=)
            foreach (var item in consulta)
            {
                Console.WriteLine(item);
            }

        }

        public static void JoinMultiple()
        {
            var categorias = new Categoria[] {
                new Categoria{ Codigo = "CC1", Nombre="Mayorista" },
                new Categoria{ Codigo = "CC1", Nombre="Minorista" },
            };

            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true, CategoriaCodigo = "CC1" },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false, CategoriaCodigo = "CC1" },
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true, CategoriaCodigo = "CC1" },
                new Cliente{ Codigo = "C4", Nombre="Roberto", CategoriaCodigo = "CC2" }
            };

            var ventas = new Venta[] {
                new Venta { Fecha = DateTime.Now.AddYears(1),Valor = 10.000M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(0),Valor = 7000M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(4),Valor = 103M, ClienteCodigo = "C4"},
                new Venta { Fecha = DateTime.Now.AddYears(5),Valor = 28M, ClienteCodigo = "C1"},
            };


            var consulta = from cliente in clientes
                           join venta in ventas
                           on cliente.Codigo equals venta.ClienteCodigo
                           join categoria in categorias
                           on cliente.CategoriaCodigo equals categoria.Codigo
                           select
                            new { Categoria = categoria.Nombre, Nombre = cliente.Nombre, Valor = venta.Valor }
                        ;


            // var consulta = clientes.Join(clienteVentas,a=)
            foreach (var item in consulta)
            {
                Console.WriteLine($"Categoria: {item.Categoria}. Nombre {item.Nombre}. Valor {item.Valor}");

            }

        }

    }

}



