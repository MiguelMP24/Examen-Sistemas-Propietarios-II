using FluentValidation;
using MediatR;
using Servicios.Api.Proveedores.Models;
using Servicios.Api.Proveedores.Persistence;

namespace Servicios.Api.Proveedores.App
{
    public class NuevoProveedor
    {
        public class Ejecuta : IRequest
        {
            public string? NombreProveedor { get; set; }
            public string? Dirección { get; set; }
            public string? Telefono { get; set; }
            public string? Correo { get; set; }
            public string? SitioWeb { get; set; }
        }

        public class Ejecutavalidacion : AbstractValidator<Ejecuta>
        {
            public Ejecutavalidacion()
            {
                RuleFor(x => x.NombreProveedor).NotEmpty();
                RuleFor(x => x.Dirección).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                RuleFor(x => x.Correo).NotEmpty();
                RuleFor(x => x.SitioWeb).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoProveedores _contexto;

            public Manejador(ContextoProveedores contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var proveedor = new ModeloProveedores
                {
                    NombreProveedor = request.NombreProveedor,
                    Dirección = request.Dirección,
                    Telefono = request.Telefono,
                    Correo = request.Correo,
                    SitioWeb = request.SitioWeb,
                };

                _contexto.ModeloProveedores.Add(proveedor);

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede guardar el proveedor");

            }
        }
    }
}
