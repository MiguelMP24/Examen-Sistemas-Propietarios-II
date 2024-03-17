using MediatR;
using Servicios.Api.Proveedores.Persistence;

namespace Servicios.Api.Proveedores.App
{
    public class BorrarProveedor
    {
        public class Ejecuta : IRequest<Unit>
        {
            public Guid? ProveedorId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
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

                _contexto.ModeloProveedores.Remove(proveedor);
                await _contexto.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
    }
}
