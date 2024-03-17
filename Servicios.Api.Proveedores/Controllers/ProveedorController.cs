using MediatR;
using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Proveedores.App;

namespace Servicios.Api.Proveedores.Controllers
{
    [Route("api/proveedor")]
    [ApiController]
    public class ProveedorController : Controller
    {
        private readonly IMediator _mediator;

        public ProveedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoProveedor.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<ModeloProveedoresDto>>> Obtener()
        {
            return await _mediator.Send(new ConsultaProveedor.Ejecuta());
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<List<ModeloProveedoresDto>>> ObtenerPorId(Guid id)
        {
            return await _mediator.Send(new ConsultaProveedorById.Ejecuta { ProveedorId = id });
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Actualizar(ActualizarProveedores.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<ActionResult<Unit>> Borrar(Guid id)
        {
            return await _mediator.Send(new BorrarProveedor.Ejecuta { ProveedorId = id });
        }

    }
}
