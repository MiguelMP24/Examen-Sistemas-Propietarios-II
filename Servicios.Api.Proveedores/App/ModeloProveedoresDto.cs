namespace Servicios.Api.Proveedores.App
{
    public class ModeloProveedoresDto
    {
        public Guid ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string Dirección { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string SitioWeb { get; set; }
    }
}
