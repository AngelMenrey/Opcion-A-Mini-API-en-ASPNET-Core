using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using miniapiaspnetcore.Domain.Entities;

namespace miniapiaspnetcore.Infrastructure.Repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByRfcAsync(string rfc);
        Task<IEnumerable<Cliente>> GetByEstatusAsync(string estatus);
        Task<bool> ExistsByRfcAsync(string rfc);
        Task<Cliente?> UpdateEstatusAsync(Guid id, string estatus);
    }
}