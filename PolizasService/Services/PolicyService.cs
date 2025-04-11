using PolizasService.Dtos.Policy;
using PolizasService.Interfaces;
using PolizasService.Mappers;
using PolizasService.Models;

namespace PolizasService.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;
        private readonly ITypePolicyRepository _typePolicyRepository;
        private readonly ICoverageRepository _coverageRepository;
        private readonly IStatePolicyRepository _statePolicyRepository;
        private readonly IClientService _clientService;
        public PolicyService(
            IPolicyRepository policyRepository, 
            ITypePolicyRepository typePolicyRepository, 
            ICoverageRepository coverageRepository, 
            IStatePolicyRepository statePolicyRepository,
            IClientService clientService
            )
        {
            _policyRepository = policyRepository;
            _typePolicyRepository = typePolicyRepository;
            _coverageRepository = coverageRepository;
            _statePolicyRepository = statePolicyRepository;
            _clientService = clientService;
        }

        

        public async Task<Result> CreatePolicyAsync(PolicyRequestDto policyRequestDto)
        {
            if (string.IsNullOrEmpty(policyRequestDto.NumeroPoliza))
            {
                return Result.FailureResult("El número de póliza es obligatorio.");
            }

            if (policyRequestDto.MontoAsegurado <= 0)
            {
                return Result.FailureResult("El monto asegurado debe ser mayor que cero.");
            }

            if (policyRequestDto.Prima <= 0)
            {
                return Result.FailureResult("La prima debe ser mayor que cero.");
            }

            var client = await _clientService.ClientExistsAsync(policyRequestDto.CedulaAsegurado);
            if (!client)
            {
                return Result.FailureResult("El cliente que ingreso no existe.");
            }

            var tipoPoliza = await _typePolicyRepository.GetByDescriptionAsync(policyRequestDto.TipoPolizaDescripcion);
            if (tipoPoliza <= 0)
            {
                return Result.FailureResult("El tipo de póliza no existe.");
            }
            var cobertura = await _coverageRepository.GetByDescriptionAsync(policyRequestDto.CoberturaDescripcion);
            if (cobertura <= 0)
            {
                return Result.FailureResult("La cobertura no existe.");
            }

            var estadoPoliza = await _statePolicyRepository.GetByDescriptionAsync(policyRequestDto.EstadoPolizaDescripcion);
            if (estadoPoliza <= 0 )
            {
                return Result.FailureResult("El estado de la póliza no existe.");
            }

            if (string.IsNullOrEmpty(policyRequestDto.Aseguradora))
            {
                return Result.FailureResult("El nombre de la aseguradora es obligatorio.");
            }

            var policyModel = await policyRequestDto.ToPolicyFromCreateDTO(_coverageRepository, _statePolicyRepository, _typePolicyRepository);
            await _policyRepository.CreateAsync(policyModel);

            return Result.SuccessResult("La póliza fue creada correctamente.");
        }

        public async Task<Result> DeleteAsync(int idPoliza)
        {
            var policy = await _policyRepository.DeleteAsync(idPoliza);

            if (policy == null)
            {
                return Result.FailureResult("La póliza no fue encontrada.");
            }

            return Result.SuccessResult("La póliza ha sido eliminada.");
        }

        public async Task<Result> GetAllAsync()
        {
            var policies = await _policyRepository.GetAllAsync();

            if (policies == null || policies.Count == 0)
            {
                return Result.FailureResult("No se encontraron pólizas.");
            }

            var policyDtos = new List<PolicyDto>();

            foreach (var policy in policies)
            {
                var tipoPoliza = await _typePolicyRepository.GetByIdAsync(policy.TipoPolizaId);
                var cobertura = await _coverageRepository.GetByIdAsync(policy.CoberturaId);
                var estadoPoliza = await _statePolicyRepository.GetByIdAsync(policy.EstadoPolizaId);
                var clientDetails = await _clientService.GetClientDetailsAsync(policy.CedulaAsegurado);

                var policyDto = policy.ToPolicyDto();

                if (clientDetails != null)
                {
                    policyDto.CedulaAsegurado = clientDetails.cedulaAsegurado;
                    policyDto.Nombre = clientDetails.nombre;
                    policyDto.PrimerApellido = clientDetails.primerApellido;
                    policyDto.SegundoApellido = clientDetails.segundoApellido;
                    policyDto.TipoPersona = clientDetails.tipoPersona;
                    policyDto.FechaNacimiento = clientDetails.fechaNacimiento;
                }
                else
                {
                    return Result.FailureResult("No se encontro el cliente.");
                }

                if (tipoPoliza != null)
                {
                    policyDto.TipoPolizaDescripcion = tipoPoliza.Descripcion;
                }

                if (cobertura != null)
                {
                    policyDto.CoberturaDescripcion = cobertura.Descripcion;
                }

                if (estadoPoliza != null)
                {
                    policyDto.EstadoPolizaDescripcion = estadoPoliza.Descripcion;
                }

                policyDtos.Add(policyDto);
            }

            return Result.SuccessResult("Pólizas obtenidas correctamente", policyDtos);
        }

        public async Task<Result> UpdateAsync(int IdPoliza, PolicyRequestDto policyRequestDto)
        {
            var tipoPoliza = await _typePolicyRepository.GetByDescriptionAsync(policyRequestDto.TipoPolizaDescripcion);
            var cobertura = await _coverageRepository.GetByDescriptionAsync(policyRequestDto.CoberturaDescripcion);
            var estadoPoliza = await _statePolicyRepository.GetByDescriptionAsync(policyRequestDto.EstadoPolizaDescripcion);

            if(tipoPoliza == 0)
            {
                return Result.FailureResult("El tipo de poliza no existe");
            }

            if (cobertura == 0)
            {
                return Result.FailureResult("La cobertura no existe");
            }

            if (estadoPoliza == 0)
            {
                return Result.FailureResult("El estado de poliza no existe");
            }

            var client = await _clientService.ClientExistsAsync(policyRequestDto.CedulaAsegurado);
            if (!client)
            {
                return Result.FailureResult("El cliente que ingreso no existe.");
            }

            if (string.IsNullOrEmpty(policyRequestDto.NumeroPoliza))
            {
                return Result.FailureResult("El número de póliza es obligatorio.");
            }

            if (policyRequestDto.MontoAsegurado <= 0)
            {
                return Result.FailureResult("El monto asegurado debe ser mayor que cero.");
            }

            if (policyRequestDto.Prima <= 0)
            {
                return Result.FailureResult("La prima debe ser mayor que cero.");
            }

            if (string.IsNullOrEmpty(policyRequestDto.Aseguradora))
            {
                return Result.FailureResult("El nombre de la aseguradora es obligatorio.");
            }

            var policy = await _policyRepository.UpdateAsync(IdPoliza, policyRequestDto);
            if (policy == null)
            {
                return Result.FailureResult("La póliza que quieres actualizar no fue encontrada.");
            }

            return Result.SuccessResult("La póliza fue modificada correctamente");
        }
    }
}
