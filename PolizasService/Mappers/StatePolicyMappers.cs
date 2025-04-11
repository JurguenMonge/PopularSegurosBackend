using PolizasService.Dtos.Coverage;
using PolizasService.Dtos.StatePolicy;
using PolizasService.Models;

namespace PolizasService.Mappers
{
    public static class StatePolicyMappers
    {
        public static StatePolicyDto? ToStatePolicyDto(this EstadoPoliza statePolicy)
        {
            return statePolicy?.IdEstadoPoliza != null && statePolicy?.Descripcion != null ? new StatePolicyDto
            {
                IdEstadoPoliza = statePolicy.IdEstadoPoliza,
                Descripcion = statePolicy.Descripcion
            } : null;
        }
        

        public static EstadoPoliza ToStatePolicyFromCreateDTO(this CreateStatePolicyRequestDto statePolicyDto)
        {
            return new EstadoPoliza
            {
                Descripcion = statePolicyDto.Descripcion
            };
        }
    }
}
