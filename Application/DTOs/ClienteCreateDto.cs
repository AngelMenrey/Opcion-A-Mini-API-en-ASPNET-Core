namespace miniapiaspnetcore.Application.DTOs
{
    public class ClienteCreateDto
    {
        public string Nombre { get; set; } = null!;
        public string RFC { get; set; } = null!;
        public string Ejecutivo { get; set; } = null!;
        public string Estatus { get; set; } = null!;
        public string TipoCliente { get; set; } = null!;
    }
}