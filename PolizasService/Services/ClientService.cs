using System.Text;
using System.Text.Json;
using PolizasService.Dtos.Client;
using PolizasService.Interfaces;

namespace PolizasService.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;
        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> ClientExistsAsync(string cedulaAsegurado)
        {
            var response = await _httpClient.GetAsync($"Cliente/{cedulaAsegurado}");
            if (response.IsSuccessStatusCode)
            {
                return true; 
            }

            return false;
        }

        public async Task<bool> CreateClientAsync(ClientDto clientDto)
        {
            var jsonContent = JsonSerializer.Serialize(clientDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Cliente", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<ClientDto?> GetClientDetailsAsync(string cedulaAsegurado)
        {
            var response = await _httpClient.GetAsync($"Cliente/{cedulaAsegurado}");
            if (response.IsSuccessStatusCode)
            {
                var clientJson = await response.Content.ReadAsStringAsync();
                var client = JsonSerializer.Deserialize<ClientDto>(clientJson);
                return client; 
            }

            return null;
        }
    }
}
