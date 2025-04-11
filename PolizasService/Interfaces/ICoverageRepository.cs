using PolizasService.Dtos.Coverage;
using PolizasService.Models;

namespace PolizasService.Interfaces
{
    public interface ICoverageRepository
    {
        Task<Cobertura> CreateAsync(Cobertura coberturaModel);
        Task<List<Cobertura>> GetAllAsync();
        Task<CoverageDto?> GetByIdAsync(int IdCobertura);
        Task<Cobertura?> UpdateAsync(int IdCobertura, CreateCoverageRequestDto cuberturaDto);
        Task<Cobertura?> DeleteAsync(int IdCobertura);
        Task<int> GetByDescriptionAsync(string descripcion);
    }
}
