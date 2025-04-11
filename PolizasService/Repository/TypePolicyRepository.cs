using Microsoft.EntityFrameworkCore;
using PolizasService.Data;
using PolizasService.Dtos.TypePolicy;
using PolizasService.Interfaces;
using PolizasService.Mappers;
using PolizasService.Models;

namespace PolizasService.Repository
{
    public class TypePolicyRepository : ITypePolicyRepository
    {
        private readonly PolizaDbContext _context;
        public TypePolicyRepository(PolizaDbContext context)
        {
            _context = context;
        }
        public async Task<TipoPoliza> CreateAsync(TipoPoliza tipoPoliza)
        {
            await _context.TipoPolizas.AddAsync(tipoPoliza);
            await _context.SaveChangesAsync();
            return tipoPoliza;
        }

        public async Task<TipoPoliza?> DeleteAsync(int TipoPolizaId)
        {
            var coverageModel = await _context.TipoPolizas.FirstOrDefaultAsync(c => c.TipoPolizaId == TipoPolizaId);
            if (coverageModel == null) return null;
            _context.TipoPolizas.Remove(coverageModel);
            await _context.SaveChangesAsync();
            return coverageModel;
        }

        public async Task<List<TipoPoliza>> GetAllAsync()
        {
            return await _context.TipoPolizas.ToListAsync();
        }

        public async Task<int> GetByDescriptionAsync(string descripcion)
        {
            var tipoPoliza = await _context.TipoPolizas
                .FirstOrDefaultAsync(tp => tp.Descripcion == descripcion);
            return tipoPoliza?.TipoPolizaId ?? 0;
        }

        public async Task<TypePolicyDto?> GetByIdAsync(int TipoPolizaId)
        {
            var typePolicyModel = await _context.TipoPolizas.FindAsync(TipoPolizaId);
            return typePolicyModel.ToTypePolicyDto();
        }

        public async Task<TipoPoliza?> UpdateAsync(int TipoPolizaId, CreateTypePolicyRequestDto typePolicyRequestDto)
        {
            var existingCoverage = await _context.TipoPolizas.FirstOrDefaultAsync(c => c.TipoPolizaId == TipoPolizaId);
            if (existingCoverage == null) return null;

            existingCoverage.Descripcion = typePolicyRequestDto.Descripcion;


            await _context.SaveChangesAsync();
            return existingCoverage;
        }
    }
}
