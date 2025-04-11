using Microsoft.EntityFrameworkCore;
using PolizasService.Data;
using PolizasService.Dtos.Coverage;
using PolizasService.Interfaces;
using PolizasService.Mappers;
using PolizasService.Models;

namespace PolizasService.Repository
{
    public class CoverageRepository : ICoverageRepository
    {
        private readonly PolizaDbContext _context;
        public CoverageRepository(PolizaDbContext context)
        {
            _context = context;
        }
        public async Task<Cobertura> CreateAsync(Cobertura coberturaModel)
        {
            await _context.Coberturas.AddAsync(coberturaModel);
            await _context.SaveChangesAsync();
            return coberturaModel;
        }

        public async Task<Cobertura?> DeleteAsync(int IdCobertura)
        {
            var coverageModel = await _context.Coberturas.FirstOrDefaultAsync(c => c.IdCobertura == IdCobertura);
            if (coverageModel == null) return null;
            _context.Coberturas.Remove(coverageModel);
            await _context.SaveChangesAsync();
            return coverageModel;
        }

        public async Task<List<Cobertura>> GetAllAsync()
        {
            return await _context.Coberturas.ToListAsync();
        }
 
        public async Task<int> GetByDescriptionAsync(string descripcion)
        {
            var cobertura = await _context.Coberturas
              .FirstOrDefaultAsync(c => c.Descripcion == descripcion);
            return cobertura?.IdCobertura ?? 0;
        }

        public async Task<CoverageDto?> GetByIdAsync(int IdCobertura)
        {
            var coverageModel =  await _context.Coberturas.FindAsync(IdCobertura);
            return coverageModel.ToCoverageDto();
        }

        public async Task<Cobertura?> UpdateAsync(int IdCobertura, CreateCoverageRequestDto cuberturaDto)
        {
            var existingCoverage = await _context.Coberturas.FirstOrDefaultAsync(c => c.IdCobertura == IdCobertura);
            if (existingCoverage == null) return null;

            existingCoverage.Descripcion = cuberturaDto.Descripcion;
           

            await _context.SaveChangesAsync();
            return existingCoverage;
        }
    }
}
