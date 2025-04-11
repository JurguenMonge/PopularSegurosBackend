using PolizasService.Dtos.TypePolicy;
using PolizasService.Models;

namespace PolizasService.Interfaces
{
    public interface ITypePolicyRepository
    {
        Task<TipoPoliza> CreateAsync(TipoPoliza tipoPoliza);
        Task<List<TipoPoliza>> GetAllAsync();
        Task<TypePolicyDto?> GetByIdAsync(int TipoPolizaId);
        Task<TipoPoliza?> UpdateAsync(int TipoPolizaId, CreateTypePolicyRequestDto typePolicyRequestDto);
        Task<TipoPoliza?> DeleteAsync(int TipoPolizaId);
        Task<int> GetByDescriptionAsync(string descripcion);
    }
}
