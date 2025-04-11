using PolizasService.Dtos.Policy;
using PolizasService.Models;

namespace PolizasService.Interfaces
{
    public interface IPolicyRepository
    {
        Task<Poliza> CreateAsync(Poliza policyModel);
        Task<List<Poliza>> GetAllAsync();
        Task<PolicyDto?> GetByIdAsync(int IdPoliza);
        Task<Poliza?> UpdateAsync(int IdPoliza, PolicyRequestDto policyRequest);
        Task<Poliza?> DeleteAsync(int idPoliza);
    }
}
