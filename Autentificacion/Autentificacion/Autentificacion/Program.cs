using Autentificacion;
using Autentificacion.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Configurar servicios IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });
}
);


//1. Configurar el esquema de Autentificacion JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{

    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});


//1. Configuracion de Politicas
builder.Services.AddAuthorization(options =>
{
    //1. Politica para Verificar claim
    //options.AddPolicy("PoliticaClaim", policy => policy.RequireClaim("CodigoAcceso"));
    options.AddPolicy("EsEcuatoriano", policy => policy.RequireClaim("Ecuatoriano"));

    //Configurable. 
    //Archivo configuracion. Politicas => Roles asociados.
    //options.AddPolicy("Gestion", policy => policy.RequireRole("Admin","Soporte"));
    //options.AddPolicy("Gestion", policy => policy.RequireClaim("Ecuatoriano"));

    //options.AddPolicy("EsEcuatoriano", policy => policy.RequireClaim("Ecuatoriano","true"));

    options.AddPolicy("PolicyComplex", policy =>
        policy.RequireAssertion(context => context.User.HasClaim(c =>
            (c.Type == "Ecuatoriano")) && context.User.IsInRole("Consulta")));



});


//Configurations
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JWT"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//2. registra el middleware que usa los esquemas de autenticación registrados
//El middleware autentificacion debe estar antes de cualquier componente que requiere autentificacion
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
