using Microsoft.EntityFrameworkCore;
using PolizasService.Data;
using PolizasService.Dtos.StatePolicy;
using PolizasService.Interfaces;
using PolizasService.Mappers;
using PolizasService.Models;

namespace PolizasService.Repository
{
    public class StatePolicyRepository : IStatePolicyRepository
    {
        private readonly PolizaDbContext _context;
        public StatePolicyRepository(PolizaDbContext context)
        {
            _context = context;
        }
        public async Task<EstadoPoliza> CreateAsync(EstadoPoliza estadoPoliza)
        {
            await _context.EstadoPolizas.AddAsync(estadoPoliza);
            await _context.SaveChangesAsync();
            return estadoPoliza;
        }

        public async Task<EstadoPoliza?> DeleteAsync(int IdEstadoPoliza)
        {
            var statePolicyModel = await _context.EstadoPolizas.FirstOrDefaultAsync(c => c.IdEstadoPoliza == IdEstadoPoliza);
            if (statePolicyModel == null) return null;
            _context.EstadoPolizas.Remove(statePolicyModel);
            await _context.SaveChangesAsync();
            return statePolicyModel;
        }

        public async Task<List<EstadoPoliza>> GetAllAsync()
        {
            return await _context.EstadoPolizas.ToListAsync();
        }

        public async Task<int> GetByDescriptionAsync(string descripcion)
        {
            var estadoPoliza = await _context.EstadoPolizas
             .FirstOrDefaultAsync(e => e.Descripcion == descripcion);
            return estadoPoliza?.IdEstadoPoliza ?? 0;
        }

        public async Task<StatePolicyDto?> GetByIdAsync(int IdEstadoPoliza)
        {
            var statePolicyModel = await _context.EstadoPolizas.FindAsync(IdEstadoPoliza);
            return statePolicyModel.ToStatePolicyDto();
        }

        public async Task<EstadoPoliza?> UpdateAsync(int IdEstadoPoliza, CreateStatePolicyRequestDto statePolicyRequestDto)
        {
            var existingStatePolicy = await _context.EstadoPolizas.FirstOrDefaultAsync(c => c.IdEstadoPoliza == IdEstadoPoliza);
            if (existingStatePolicy == null) return null;

            existingStatePolicy.Descripcion = statePolicyRequestDto.Descripcion;


            await _context.SaveChangesAsync();
            return existingStatePolicy;
        }
    }
}
