using AutoMapper;
using MediatR;
using Servicios.Api.Proveedores.Models;
using Servicios.Api.Proveedores.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Servicios.Api.Proveedores.App
{
    public class ConsultaProveedorById
    {
        public class Ejecuta : IRequest<List<ModeloProveedoresDto>>
        {
            public Guid? ProveedorId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, List<ModeloProveedoresDto>>
        {

            private readonly ContextoProveedores _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoProveedores contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<ModeloProveedoresDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var proveedores = await _contexto.ModeloProveedores
                    .Where(proveedor => proveedor.ProveedorId == request.ProveedorId)
                    .ToListAsync(cancellationToken);

                var proveedoresDto = _mapper.Map<List<ModeloProveedores>, List<ModeloProveedoresDto>>(proveedores);
                return proveedoresDto;
            }
        }
    }
}
