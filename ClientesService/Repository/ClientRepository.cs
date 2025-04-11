using ClientesService.Data;
using ClientesService.Dtos;
using ClientesService.Interfaces;
using ClientesService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesService.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientesDbContext _context;

        public ClientRepository(ClientesDbContext context) 
        { 
            _context = context;
        }

        public async Task<Cliente> CreateAsync(Cliente clienteModel)
        {
            await _context.Clientes.AddAsync(clienteModel);
            await _context.SaveChangesAsync();
            return clienteModel;
        }

        public async Task<Cliente?> DeleteAsync(string cedulaAsegurado)
        {
            var clienteModel = await _context.Clientes.FirstOrDefaultAsync(c => c.CedulaAsegurado == cedulaAsegurado);

            if (clienteModel == null) return null;

            clienteModel.EstaEliminado = true;

            await _context.SaveChangesAsync();
            return clienteModel;
            
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                                .Where(c => c.EstaEliminado == false)
                                .ToListAsync(); 
        }

        public async Task<Cliente?> GetByIdAsync(string cedula)
        {
            return await _context.Clientes.FindAsync(cedula);
        }

        public async Task<Cliente?> UpdateAsync(string cedulaAsegurado, UpdateClientRequestDto clientDto)
        {
            var existingClient = await _context.Clientes.FirstOrDefaultAsync(c => c.CedulaAsegurado == cedulaAsegurado);
            if (existingClient == null) return null;

            existingClient.CedulaAsegurado = clientDto.CedulaAsegurado;
            existingClient.Nombre = clientDto.Nombre;
            existingClient.PrimerApellido = clientDto.PrimerApellido;
            existingClient.SegundoApellido = clientDto.SegundoApellido;
            existingClient.TipoPersona = clientDto.TipoPersona;
            existingClient.FechaNacimiento = (DateOnly)clientDto.FechaNacimiento;

            await _context.SaveChangesAsync();
            return existingClient;

        }
    }
}
