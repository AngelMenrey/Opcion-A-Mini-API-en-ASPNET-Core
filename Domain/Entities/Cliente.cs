using System;

namespace miniapiaspnetcore.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string RFC { get; set; } = null!;
        public string Ejecutivo { get; set; } = null!;
        public string Estatus { get; set; } = null!;
        public string TipoCliente { get; set; } = null!;
    }
}