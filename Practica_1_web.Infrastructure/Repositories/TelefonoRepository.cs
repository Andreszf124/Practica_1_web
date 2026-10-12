using Microsoft.EntityFrameworkCore;
using Practica_1_web.Application.Interfaces;
using Practica_1_web.Domain.Entities;
using Practica_1_web.Infrastructure.Data;

namespace Practica_1_web.Infrastructure.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly ApplicationDbContext _context;

        public TelefonoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Telefono>> GetAllAsync()
        {
            return await _context.Telefonos
                .Include(t => t.Cliente)
                .ToListAsync();
        }

        public async Task<List<Telefono>> GetByClienteIdAsync(int clienteId)
        {
            return await _context.Telefonos
                .Where(t => t.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<Telefono?> GetByIdAsync(int id)
        {
            return await _context.Telefonos
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Telefono telefono)
        {
            await _context.Telefonos.AddAsync(telefono);
        }

        public Task UpdateAsync(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);
            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
