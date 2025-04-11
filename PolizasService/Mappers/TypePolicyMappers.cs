using PolizasService.Dtos.StatePolicy;
using PolizasService.Dtos.TypePolicy;
using PolizasService.Models;

namespace PolizasService.Mappers
{
    public static class TypePolicyMappers
    {
        public static TypePolicyDto? ToTypePolicyDto(this TipoPoliza typePolicy)
        {
            return typePolicy?.TipoPolizaId != null && typePolicy?.Descripcion != null ? new TypePolicyDto
            {
                Descripcion = typePolicy.Descripcion
            } : null;
        }


        public static TipoPoliza ToTypePolicyFromCreateDTO(this CreateTypePolicyRequestDto typePolicyDto)
        {
            return new TipoPoliza
            {
                Descripcion = typePolicyDto.Descripcion
            };
        }
    }
}
