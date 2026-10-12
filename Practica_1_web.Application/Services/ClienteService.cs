using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Interfaces;
using Practica_1_web.Domain.Entities;

namespace Practica_1_web.Application.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClienteDto>> GetAllClientesAsync()
        {
            var clientes = await _repository.GetAllAsync();
            return clientes.Select(c => new ClienteDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Email = c.Email,
                Direccion = c.Direccion,
                Telefonos = c.Telefonos.Select(t => new TelefonoDto
                {
                    Id = t.Id,
                    Numero = t.Numero,
                    Tipo = t.Tipo,
                    ClienteId = t.ClienteId
                }).ToList()
            }).ToList();
        }

        public async Task<ClienteDto?> GetClienteByIdAsync(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return null;

            return new ClienteDto
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Email = cliente.Email,
                Direccion = cliente.Direccion,
                Telefonos = cliente.Telefonos.Select(t => new TelefonoDto
                {
                    Id = t.Id,
                    Numero = t.Numero,
                    Tipo = t.Tipo,
                    ClienteId = t.ClienteId
                }).ToList()
            };
        }

        public async Task<ClienteDto> CreateClienteAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Email = clienteDto.Email,
                Direccion = clienteDto.Direccion
            };

            await _repository.AddAsync(cliente);
            await _repository.SaveChangesAsync();

            clienteDto.Id = cliente.Id;
            return clienteDto;
        }

        public async Task UpdateClienteAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Id = clienteDto.Id,
                Nombre = clienteDto.Nombre,
                Email = clienteDto.Email,
                Direccion = clienteDto.Direccion
            };

            await _repository.UpdateAsync(cliente);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
