namespace LinqBasico
{

 
    public static class LinqGroup
    {


        public static void GrupoVariosCriterios() {

            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true, Edad = 19, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false, Edad = 30 , Tipo = ClienteTipo.Plata},
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true,  Edad = 18, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C4", Nombre="Roberto", Edad = 35, Tipo = ClienteTipo.Plata  },
                new Cliente{ Nombre="ANGEL", Edad = 35, Tipo = ClienteTipo.Plata },
                new Cliente{ Nombre="Juan", Edad = 19 , Tipo = ClienteTipo.Bronce},
                new Cliente{ Nombre="Carmen", Edad = 35, Tipo = ClienteTipo.Oro }
            };

            //Agrupara cliente. Tipo, Edad
            var consulta = from cliente in clientes
                           group cliente by new { cliente.Tipo, cliente.Edad }
                           ;

            foreach (var grupo in consulta)
            {
                
                Console.WriteLine($"Tipo: {grupo.Key.Tipo}. Edad: {grupo.Key.Edad}");
                 
                //Recorro
                foreach (var cliente in grupo)
                {
                    //Console.WriteLine(cliente);  => Utliza el ToString del objeto.
                    Console.WriteLine($"Nombre {cliente.Nombre}. Edad {cliente.Edad}. Activo {cliente.Activo}");

                }
            }

        }


        public static void GrupoFuncionesAgregacion() {

            var personas = new List<Persona>()
            {
                new Persona() {
                    Nombre = "Maria", Sexo = Sexo.Femenino, CuidadNacimiento = "Cuenca", Edad = 23
                },
                new Persona() {
                    Nombre = "Carlos", Sexo = Sexo.Masculino, CuidadNacimiento = "Quito", Edad = 45
                }
            };

            personas.Add(new Persona() { 
                Nombre = "Luis", Sexo = Sexo.Masculino, CuidadNacimiento = "Quito",
                Edad = 12
            });

            personas.Add(new Persona()
            {
                Nombre = "Mateo",
                Sexo = Sexo.Masculino,
                CuidadNacimiento = "Loja",
                Edad = 32
            });


            //Conocer los totales de hombres y mujeres
            var consulta = from persona in personas
                           group persona by persona.Sexo into grupoSexo
                           //Proyeccion
                           select new
                           {  
                               //Obtener los valores por los cuales se agrupo
                               Sexo = grupoSexo.Key,
                               //Aplicar una funcion de agregacion a cada uno de los grupos.
                               //Count, Sum, Min, Max, etc. 
                               Total = grupoSexo.Count(),
                               PromedioEdad = grupoSexo.Average(a => a.Edad),
                               Cuiadades = String.Join(",", grupoSexo.Select(a => a.CuidadNacimiento).Distinct()) 
                           };

            foreach (var item in consulta)
            {
                Console.WriteLine(string.Format("Sexo {0}, Total {1}. Promedio Edad {2}. City: {3}", item.Sexo, item.Total, item.PromedioEdad, item.Cuiadades));
            }



        }


        public static void GrupoBasico() {


            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true, Edad = 19, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false, Edad = 30 , Tipo = ClienteTipo.Plata},
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true,  Edad = 18, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C4", Nombre="Roberto", Edad = 35, Tipo = ClienteTipo.Plata  },
                new Cliente{ Nombre="ANGEL", Edad = 35, Tipo = ClienteTipo.Plata },
                new Cliente{ Nombre="Juan", Edad = 19 , Tipo = ClienteTipo.Bronce},
                new Cliente{ Nombre="Carmen", Edad = 35, Tipo = ClienteTipo.Oro }
            };


            var consultaXTipo = from cliente in clientes
                                group cliente by cliente.Tipo into grupoXTipo
                                select grupoXTipo
                                ;

            foreach (var grupo in consultaXTipo)
            {
                //Objeto
                //Key: (Valor por el cual realice el agrupamiento)
                //Value: Lista Objetos que se encuentra agrupados por campos configurados
                Console.WriteLine($"key - Tipo: {grupo.Key}");

                //Recorro
                foreach (var cliente in grupo)
                {
                    //Console.WriteLine(cliente);  => Utliza el ToString del objeto.
                    Console.WriteLine($"Nombre {cliente.Nombre}. Edad {cliente.Edad}. Activo {cliente.Activo}");

                }
            }



        }


        public static void GroupFilter()
        {

            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true, Edad = 19, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false, Edad = 30 , Tipo = ClienteTipo.Plata},
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true,  Edad = 18, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C4", Nombre="Roberto", Edad = 35, Tipo = ClienteTipo.Plata  },
                new Cliente{ Nombre="ANGEL", Edad = 35, Tipo = ClienteTipo.Plata },
                new Cliente{ Nombre="Juan", Edad = 19 , Tipo = ClienteTipo.Bronce},
                new Cliente{ Nombre="Carmen", Edad = 35, Tipo = ClienteTipo.Oro }
            };

            //Agrupar por edad, y recuperar los grupos que tenga minimo 2 elementos
            var consulta = from cliente in clientes
                           group cliente by cliente.Edad into grupo
                           where
                                grupo.Count() >= 2
                           select grupo;
            ;

            foreach (var groupo in consulta)
            {
                Console.WriteLine($"Clave {groupo.Key}");
                foreach (var cliente in groupo)
                {
                    Console.WriteLine($"{cliente}");
                }
            }
        }


        public static void GroupAgregacion()
        {

            var ventas = new Venta[] {
                new Venta { Fecha = DateTime.Now.AddYears(1),Valor = 15.20M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(0),Valor = 105.3M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(4),Valor = 83M, ClienteCodigo = "C4"},
                new Venta { Fecha = DateTime.Now.AddYears(5),Valor = 28M, ClienteCodigo = "C1"},
                new Venta { Fecha = DateTime.Now.AddYears(5),Valor = 28M, ClienteCodigo = "C2"},
                new Venta { Fecha = DateTime.Now.AddYears(5),Valor = 28M, ClienteCodigo = "C2"},
                new Venta { Fecha = DateTime.Now.AddYears(5),Valor = 28M, ClienteCodigo = "C3"},
            };

            //Recuperar el total de ventas x Cliente.
            var consulta = from venta in ventas
                           group venta by venta.ClienteCodigo into grupo
                           select new
                           {
                               ClienteCodigo = grupo.Key,
                               TotalVentas = grupo.Sum(a => a.Valor),
                               NumeroVentas = grupo.Count()
                           };

            foreach (var item in consulta)
            {
                Console.WriteLine($"ClienteCodigo: {item.ClienteCodigo}. TotalVentas: {item.TotalVentas}. NumeroVentas: {item.NumeroVentas}.");

            }
        }

        public static void Group()
        {

            var clientes = new Cliente[] {
                new Cliente{ Codigo = "C1", Nombre="Luis", Activo=true, Edad = 19, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C2", Nombre="Carlos", Activo=false, Edad = 30 , Tipo = ClienteTipo.Plata},
                new Cliente{ Codigo = "C3", Nombre="Maria", Activo=true,  Edad = 18, Tipo = ClienteTipo.Oro },
                new Cliente{ Codigo = "C4", Nombre="Roberto", Edad = 35, Tipo = ClienteTipo.Plata  },
                new Cliente{ Nombre="ANGEL", Edad = 35, Tipo = ClienteTipo.Plata },
                new Cliente{ Nombre="Juan", Edad = 19 , Tipo = ClienteTipo.Bronce},
                new Cliente{ Nombre="Carmen", Edad = 35, Tipo = ClienteTipo.Oro }
            };

            //Agrupar por edad
            var consulta = from cliente in clientes
                           group cliente by cliente.Edad
                           ;

            foreach (var groupo in consulta)
            {
                Console.WriteLine($"Clave {groupo.Key}");
                foreach (var cliente in groupo)
                {
                    Console.WriteLine($"{cliente}");
                }
            }

        }


        public static void ObtenerRepetidos() { 
        

        
        }
    }

}



