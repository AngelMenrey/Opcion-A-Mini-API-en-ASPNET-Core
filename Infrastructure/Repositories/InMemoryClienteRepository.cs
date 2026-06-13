using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using miniapiaspnetcore.Domain.Entities;
using miniapiaspnetcore.Infrastructure.Repositories;

namespace miniapiaspnetcore.Infrastructure.Repositories
{
    public class InMemoryClienteRepository : IClienteRepository
    {
        private readonly ConcurrentDictionary<Guid, Cliente> _store = new();

        public Task AddAsync(Cliente cliente)
        {
            _store[cliente.Id] = cliente;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Cliente>> GetAllAsync() =>
            Task.FromResult(_store.Values.AsEnumerable());

        public Task<Cliente?> GetByRfcAsync(string rfc) =>
            Task.FromResult(_store.Values.FirstOrDefault(c => string.Equals(c.RFC, rfc, StringComparison.OrdinalIgnoreCase)));

        public Task<IEnumerable<Cliente>> GetByEstatusAsync(string estatus) =>
            Task.FromResult(_store.Values.Where(c => string.Equals(c.Estatus, estatus, StringComparison.OrdinalIgnoreCase)));

        public Task<bool> ExistsByRfcAsync(string rfc) =>
            Task.FromResult(_store.Values.Any(c => string.Equals(c.RFC, rfc, StringComparison.OrdinalIgnoreCase)));

        public Task<Cliente?> UpdateEstatusAsync(Guid id, string estatus)
        {
            if (_store.TryGetValue(id, out var c))
            {
                c.Estatus = estatus;
                _store[id] = c;
                return Task.FromResult<Cliente?>(c);
            }
            return Task.FromResult<Cliente?>(null);
        }
    }
}