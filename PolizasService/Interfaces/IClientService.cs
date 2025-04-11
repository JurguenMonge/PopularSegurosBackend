using PolizasService.Dtos.Client;

namespace PolizasService.Interfaces
{
    public interface IClientService
    {
        Task<bool> ClientExistsAsync(string cedulaAsegurado);

        Task<ClientDto?> GetClientDetailsAsync(string cedulaAsegurado);
        Task<bool> CreateClientAsync(ClientDto clientDto);
    }
}
