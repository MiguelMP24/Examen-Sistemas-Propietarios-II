using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Servicios.Api.Proveedores.App;
using Servicios.Api.Proveedores.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllers().AddFluentValidation(cfg =>
{
    cfg.RegisterValidatorsFromAssemblyContaining<NuevoProveedor>();
    cfg.RegisterValidatorsFromAssemblyContaining<ActualizarProveedores>();
});
builder.Services.AddMediatR(typeof(NuevoProveedor.Manejador).Assembly);
builder.Services.AddMediatR(typeof(ActualizarProveedores.Manejador).Assembly);

builder.Services.AddDbContext<ContextoProveedores>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("ConexionDB"));
});

builder.Services.AddAutoMapper(typeof(ConsultaProveedor.Ejecuta));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
