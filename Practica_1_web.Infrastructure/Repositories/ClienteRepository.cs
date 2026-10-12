using Microsoft.EntityFrameworkCore;
using Practica_1_web.Application.Interfaces;
using Practica_1_web.Domain.Entities;
using Practica_1_web.Infrastructure.Data;

namespace Practica_1_web.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Include(c => c.Telefonos)
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .Include(c => c.Telefonos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
