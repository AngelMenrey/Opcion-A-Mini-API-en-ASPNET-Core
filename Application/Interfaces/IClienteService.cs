using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using miniapiaspnetcore.Application.DTOs;

namespace miniapiaspnetcore.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDto> CreateAsync(ClienteCreateDto dto);
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByRfcAsync(string rfc);
        Task<IEnumerable<ClienteDto>> GetByEstatusAsync(string estatus);
        Task<ClienteDto?> ChangeEstatusAsync(Guid id, string estatus);
    }
}