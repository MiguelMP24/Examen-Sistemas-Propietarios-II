using AutoMapper;
using Servicios.Api.Proveedores.Models;

namespace Servicios.Api.Proveedores.App
{
    public class MappingProveedores : Profile
    {
        public MappingProveedores()
        {
            CreateMap<ModeloProveedores, ModeloProveedoresDto>();
        }
    }
}
