using PolizasService.Dtos.Policy;
using PolizasService.Models;

namespace PolizasService.Interfaces
{
    public interface IPolicyService
    {
        Task<Result> CreatePolicyAsync(PolicyRequestDto policyRequestDto);
        Task<Result> GetAllAsync();
        Task<Result> DeleteAsync(int IdPoliza);
        Task<Result> UpdateAsync(int IdPoliza, PolicyRequestDto policyRequestDto);
    }
}
