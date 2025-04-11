using Microsoft.EntityFrameworkCore;
using PolizasService.Data;
using PolizasService.Dtos.Policy;
using PolizasService.Interfaces;
using PolizasService.Models;

namespace PolizasService.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly PolizaDbContext _context;
        private readonly ICoverageRepository _coverageRepository;
        private readonly ITypePolicyRepository _typePolicyRepository;
        private readonly IStatePolicyRepository _statePolicyRepository;
        public PolicyRepository(PolizaDbContext context, ICoverageRepository coverageRepository, ITypePolicyRepository typePolicyRepository, IStatePolicyRepository statePolicyRepository)
        {
            _context = context;
            _coverageRepository = coverageRepository;
            _typePolicyRepository = typePolicyRepository;
            _statePolicyRepository = statePolicyRepository;
        }

        public async Task<Poliza> CreateAsync(Poliza policyModel)
        {
            await _context.Polizas.AddAsync(policyModel);
            await _context.SaveChangesAsync();
            return policyModel;
        }

        public async Task<Poliza?> DeleteAsync(int IdPoliza)
        {
            var policy = await _context.Polizas.FirstOrDefaultAsync(p => p.IdPoliza == IdPoliza);

            if (policy == null)
            {
                return null;
            }
            policy.EstaEliminado = true;

            await _context.SaveChangesAsync();

            return policy;
        }

        public async Task<List<Poliza>> GetAllAsync()
        {
            return await _context.Polizas
                         .Where(p => p.EstaEliminado == false)
                         .ToListAsync();
        }

        public Task<PolicyDto?> GetByIdAsync(int IdPoliza)
        {
            throw new NotImplementedException();
        }

        public async Task<Poliza?> UpdateAsync(int IdPoliza, PolicyRequestDto policyRequest)
        {
            var existingPolicy = await _context.Polizas.FirstOrDefaultAsync(c => c.IdPoliza == IdPoliza);

            if (existingPolicy == null) return null;
            if (existingPolicy.EstaEliminado == true) return null;

            var tipoPolizaId = await _typePolicyRepository.GetByDescriptionAsync(policyRequest.TipoPolizaDescripcion);
            var CoberturaId = await _coverageRepository.GetByDescriptionAsync(policyRequest.CoberturaDescripcion);
            var estadoId = await _statePolicyRepository.GetByDescriptionAsync(policyRequest.EstadoPolizaDescripcion);

            existingPolicy.NumeroPoliza = policyRequest.NumeroPoliza;
            existingPolicy.CedulaAsegurado = policyRequest.CedulaAsegurado;
            existingPolicy.TipoPolizaId = tipoPolizaId;
            existingPolicy.CoberturaId = CoberturaId;
            existingPolicy.EstadoPolizaId = estadoId;
            existingPolicy.MontoAsegurado = policyRequest.MontoAsegurado;
            existingPolicy.FechaVencimiento = policyRequest.FechaVencimiento;
            existingPolicy.FechaEmision = policyRequest.FechaEmision;
            existingPolicy.Prima = policyRequest.Prima;
            existingPolicy.Periodo = policyRequest.Periodo;
            existingPolicy.FechaInclusion = policyRequest.FechaInclusion;
            existingPolicy.Aseguradora = policyRequest.Aseguradora;

            await _context.SaveChangesAsync();
            return existingPolicy;
        }
    }
}
