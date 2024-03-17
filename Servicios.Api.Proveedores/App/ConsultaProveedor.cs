using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Servicios.Api.Proveedores.Models;
using Servicios.Api.Proveedores.Persistence;

namespace Servicios.Api.Proveedores.App
{
    public class ConsultaProveedor
    {
        public class Ejecuta : IRequest<List<ModeloProveedoresDto>> { }

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
                var libros = await _contexto.ModeloProveedores.ToListAsync(cancellationToken);
                var librosDto = _mapper.Map<List<ModeloProveedores>, List<ModeloProveedoresDto>>(libros);
                return librosDto;
            }
        }
    }
}
