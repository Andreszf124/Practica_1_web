using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Interfaces;
using Practica_1_web.Domain.Entities;

namespace Practica_1_web.Application.Services
{
    public class TelefonoService
    {
        private readonly ITelefonoRepository _repository;

        public TelefonoService(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TelefonoDto>> GetAllTelefonosAsync()
        {
            var telefonos = await _repository.GetAllAsync();
            return telefonos.Select(t => new TelefonoDto
            {
                Id = t.Id,
                Numero = t.Numero,
                Tipo = t.Tipo,
                ClienteId = t.ClienteId
            }).ToList();
        }

        public async Task<List<TelefonoDto>> GetTelefonosByClienteIdAsync(int clienteId)
        {
            var telefonos = await _repository.GetByClienteIdAsync(clienteId);
            return telefonos.Select(t => new TelefonoDto
            {
                Id = t.Id,
                Numero = t.Numero,
                Tipo = t.Tipo,
                ClienteId = t.ClienteId
            }).ToList();
        }

        public async Task<TelefonoDto?> GetTelefonoByIdAsync(int id)
        {
            var telefono = await _repository.GetByIdAsync(id);
            if (telefono == null) return null;

            return new TelefonoDto
            {
                Id = telefono.Id,
                Numero = telefono.Numero,
                Tipo = telefono.Tipo,
                ClienteId = telefono.ClienteId
            };
        }

        public async Task<TelefonoDto> CreateTelefonoAsync(TelefonoDto telefonoDto)
        {
            var telefono = new Telefono
            {
                Numero = telefonoDto.Numero,
                Tipo = telefonoDto.Tipo,
                ClienteId = telefonoDto.ClienteId
            };

            await _repository.AddAsync(telefono);
            await _repository.SaveChangesAsync();

            telefonoDto.Id = telefono.Id;
            return telefonoDto;
        }

        public async Task UpdateTelefonoAsync(TelefonoDto telefonoDto)
        {
            // Fetch the existing entity to avoid tracking conflicts
            var telefono = await _repository.GetByIdAsync(telefonoDto.Id);

            if (telefono == null)
                throw new InvalidOperationException($"Teléfono con ID {telefonoDto.Id} no encontrado.");

            // Update the existing entity's properties
            telefono.Numero = telefonoDto.Numero;
            telefono.Tipo = telefonoDto.Tipo;
            telefono.ClienteId = telefonoDto.ClienteId;

            await _repository.UpdateAsync(telefono);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteTelefonoAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
