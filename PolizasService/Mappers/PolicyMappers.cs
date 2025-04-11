using PolizasService.Dtos.Policy;
using PolizasService.Interfaces;
using PolizasService.Models;
using PolizasService.Services;

namespace PolizasService.Mappers
{
    public static class PolicyMappers
    {
        public static PolicyDto? ToPolicyDto(this Poliza poliza)
        {
            return new PolicyDto
            {
                  IdPoliza = poliza.IdPoliza,
                  NumeroPoliza = poliza.NumeroPoliza,
                  CedulaAsegurado = poliza.CedulaAsegurado,
                  TipoPolizaId = poliza.TipoPolizaId,
                  CoberturaId = poliza.CoberturaId,
                  EstadoPolizaId = poliza.EstadoPolizaId,
                  MontoAsegurado = poliza.MontoAsegurado,
                  FechaVencimiento = poliza.FechaVencimiento,
                  FechaEmision = poliza.FechaEmision,
                  Prima = poliza.Prima,
                  Periodo = poliza.Periodo ,
                  FechaInclusion = poliza.FechaInclusion,
                  Aseguradora = poliza.Aseguradora,
            };
        }

        public static async Task<Poliza> ToPolicyFromCreateDTO(this PolicyRequestDto policyRequestDto, 
            ICoverageRepository coverageRepository, 
            IStatePolicyRepository statePolicyRepository, 
            ITypePolicyRepository typePolicyRepository)
        {
            var tipoPolizaId = await typePolicyRepository.GetByDescriptionAsync(policyRequestDto.TipoPolizaDescripcion);
            var coberturaId = await coverageRepository.GetByDescriptionAsync(policyRequestDto.CoberturaDescripcion);
            var estadoPolizaId = await statePolicyRepository.GetByDescriptionAsync(policyRequestDto.EstadoPolizaDescripcion);

            return new Poliza
            {
                NumeroPoliza = policyRequestDto.NumeroPoliza,
                CedulaAsegurado = policyRequestDto.CedulaAsegurado,
                TipoPolizaId = tipoPolizaId,
                CoberturaId = coberturaId,
                EstadoPolizaId = estadoPolizaId,
                MontoAsegurado = policyRequestDto.MontoAsegurado,
                FechaVencimiento = policyRequestDto.FechaVencimiento,
                FechaEmision = policyRequestDto.FechaEmision,
                Prima = policyRequestDto.Prima,
                Periodo = policyRequestDto.Periodo,
                FechaInclusion = policyRequestDto.FechaInclusion,
                Aseguradora = policyRequestDto.Aseguradora,
                EstaEliminado = false
            };
        }
    }
}
