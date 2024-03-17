using FluentValidation;
using MediatR;
using Servicios.Api.Proveedores.Persistence;

namespace Servicios.Api.Proveedores.App
{
    public class ActualizarProveedores
    {
        public class Ejecuta : IRequest
        {
            public Guid ProveedorId { get; set; }
            public string NombreProveedor { get; set; }
            public string Dirección { get; set; }
            public string Telefono { get; set; }
            public string Correo { get; set; }
            public string SitioWeb { get; set; }
        }

        public class Ejecutavalidacion : AbstractValidator<Ejecuta>
        {
            public Ejecutavalidacion()
            {
                RuleFor(x => x.ProveedorId).NotEmpty();
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
                var proveedor = await _contexto.ModeloProveedores.FindAsync(request.ProveedorId);

                if (proveedor == null)
                {
                    throw new Exception("Proveedor no encontrado");
                }

                proveedor.NombreProveedor = request.NombreProveedor;
                proveedor.Dirección = request.Dirección;
                proveedor.Telefono = request.Telefono;
                proveedor.Correo = request.Correo;
                proveedor.SitioWeb = request.SitioWeb;

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede actualizar el proveedor");

            }
        }
    }
}
