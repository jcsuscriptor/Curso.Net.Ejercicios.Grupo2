using Curso.Biblioteca.Infraestructura;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Agregar conexion a base de datos
builder.Services.AddDbContext<BibliotecaDbContext>(options =>
{
    //Opcion 1. Sql Server
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Biblioteca"));

    //Opcion 2. SqLite
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    var dbPath = Path.Join(path, builder.Configuration.GetConnectionString("Biblioteca"));
    Debug.WriteLine($"dbPath: {dbPath}");

    options.UseSqlite($"Data Source={dbPath}");

});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
