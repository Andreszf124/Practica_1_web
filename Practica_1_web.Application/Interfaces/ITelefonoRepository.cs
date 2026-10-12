using Practica_1_web.Domain.Entities;

namespace Practica_1_web.Application.Interfaces
{
    public interface ITelefonoRepository
    {
        Task<List<Telefono>> GetAllAsync();
        Task<List<Telefono>> GetByClienteIdAsync(int clienteId);
        Task<Telefono?> GetByIdAsync(int id);
        Task AddAsync(Telefono telefono);
        Task UpdateAsync(Telefono telefono);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
