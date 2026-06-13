using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using miniapiaspnetcore.Application.DTOs;
using miniapiaspnetcore.Application.Interfaces;
using miniapiaspnetcore.Domain.Entities;
using miniapiaspnetcore.Domain.Exceptions;
using miniapiaspnetcore.Infrastructure.Repositories;

namespace miniapiaspnetcore.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        public ClienteService(IClienteRepository repo) => _repo = repo;

        public async Task<ClienteDto> CreateAsync(ClienteCreateDto dto)
        {
            var exists = await _repo.ExistsByRfcAsync(dto.RFC);
            if (exists) throw new DuplicateRfcException(dto.RFC);

            var entity = new Cliente
            {
                Id = Guid.NewGuid(),
                Nombre = dto.Nombre,
                RFC = dto.RFC,
                Ejecutivo = dto.Ejecutivo,
                Estatus = dto.Estatus,
                TipoCliente = dto.TipoCliente
            };
            await _repo.AddAsync(entity);
            return ToDto(entity);
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync() =>
            (await _repo.GetAllAsync()).Select(ToDto);

        public async Task<ClienteDto?> GetByRfcAsync(string rfc) =>
            ToDto(await _repo.GetByRfcAsync(rfc));

        public async Task<IEnumerable<ClienteDto>> GetByEstatusAsync(string estatus) =>
            (await _repo.GetByEstatusAsync(estatus)).Select(ToDto);

        public async Task<ClienteDto?> ChangeEstatusAsync(Guid id, string estatus)
        {
            var updated = await _repo.UpdateEstatusAsync(id, estatus);
            return ToDto(updated);
        }

        private static ClienteDto? ToDto(Cliente? e) =>
            e is null ? null : new ClienteDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                RFC = e.RFC,
                Ejecutivo = e.Ejecutivo,
                Estatus = e.Estatus,
                TipoCliente = e.TipoCliente
            };
    }
}