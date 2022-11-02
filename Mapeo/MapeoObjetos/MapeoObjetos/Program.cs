// See https://aka.ms/new-console-template for more information
using AutoMapper;
using AutoMapper.QueryableExtensions;

//EjerciciosMapeo.MapeoDefault();
//EjerciciosMapeo.MapeoQuery();
EjerciciosMapeo.MapeoClassWithConstruct();


public static class EjerciciosMapeo {

    /// <summary>
    /// Doc:
    /// https://docs.automapper.org/en/stable/Queryable-Extensions.html?highlight=ConstructUsing#custom-destination-type-constructors
    /// </summary>
    public static void MapeoClassWithConstruct()
    {
        var client = GetClient();

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Client, ClassWithConstruct>()
                .ConstructUsing((src,des) => new ClassWithConstruct(Guid.NewGuid()))
                ;
            //Otros Mapeos...

        });

        //2. Utilizar el mapeo
        var mapper = new Mapper(config);
        var classWithConstruct = mapper.Map<ClassWithConstruct>(client);


        Console.WriteLine("Print Client");

        Console.WriteLine(ClientToString(client));

        Console.WriteLine("Print ClientDto");

        Console.WriteLine(ClassWithConstructToString(classWithConstruct));


    }

        /// <summary>
        /// Queryable Extensions
        /// </summary>
        public static void MapeoQuery() {

        var list = new List<Client>();
        list.Add(GetClient());

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Client, ClientDto>();
            //Otros Mapeos...

        });

        var mapper = new Mapper(config);
        var dtos = list.AsQueryable().ProjectTo<ClientDto>(mapper.ConfigurationProvider);

     
        Console.WriteLine("Print ClientDto");

        foreach (var clientDto in dtos)
        {
            Console.WriteLine(ClientDtoToString(clientDto));
        }
        
    }

    public static void MapeoDefault()
    {
        var client = GetClient();


        //1. Configurar mapeo

        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Client, ClientDto>(); 
            //Otros Mapeos...

        });


        //2. Utilizar el mapeo
        var mapper = new Mapper(config);
        var clientDto = mapper.Map<ClientDto>(client);


        Console.WriteLine("Print Client");

        Console.WriteLine(ClientToString(client));

        Console.WriteLine("Print ClientDto");

        Console.WriteLine(ClientDtoToString(clientDto));


    }

    private static Client GetClient() {
        var client = new Client()
        {
            ClientId = 1,
            CreationDate = DateTime.Now.ToString(),
            Email = "foo@bar.com",
            LastName = "Suarez Camacho",
            Name = "Carlos Luis",
            Password = "******"
        };

        return client;

    }

    private static string ClassWithConstructToString(ClassWithConstruct classWithConstruct) {
        return $"Id: {classWithConstruct.Id}. Name: {classWithConstruct.Name}";
    }
    private static string ClientDtoToString(ClientDto client) {

        return $"Nombre: {client.Name}. Apellido: {client.LastName}. Email: {client.Email}";
    }

    private static string ClientToString(Client client)
    {

        return $"ClientId: {client.ClientId}. Nombre: {client.Name}. Apellido: {client.LastName}. Email: {client.Email} CreationDate: {client.CreationDate}. ";
    }

}


public class ClassWithConstruct {
    public ClassWithConstruct(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = null;

}


public class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string CreationDate { get; set; }

    public string Password { get; set; }
}

public class ClientDto
{
    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    
}
