using PolizasService.Dtos.StatePolicy;
using PolizasService.Models;

namespace PolizasService.Interfaces
{
    public interface IStatePolicyRepository
    {
        Task<EstadoPoliza> CreateAsync(EstadoPoliza estadoPoliza);
        Task<List<EstadoPoliza>> GetAllAsync();
        Task<StatePolicyDto?> GetByIdAsync(int IdEstadoPoliza);
        Task<EstadoPoliza?> UpdateAsync(int IdEstadoPoliza, CreateStatePolicyRequestDto statePolicyRequestDto);
        Task<EstadoPoliza?> DeleteAsync(int IdEstadoPoliza);
        Task<int> GetByDescriptionAsync(string descripcion);
    }
}
