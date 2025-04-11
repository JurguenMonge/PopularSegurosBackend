using ClientesService.Dtos;
using ClientesService.Models;

namespace ClientesService.Interfaces
{
    public interface IClientRepository
    {
        Task<Cliente> CreateAsync(Cliente clienteModel);
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(string cedulaAsegurado);
        Task<Cliente?> UpdateAsync(string cedulaAsegurado, UpdateClientRequestDto clientDto);
        Task<Cliente?> DeleteAsync(string cedulaAsegurado);
    }
}
