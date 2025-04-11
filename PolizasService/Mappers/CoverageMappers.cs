using PolizasService.Dtos.Coverage;
using PolizasService.Dtos.StatePolicy;
using PolizasService.Models;

namespace PolizasService.Mappers
{
    public static class CoverageMappers
    {
        public static CoverageDto? ToCoverageDto(this Cobertura coverage)
        {
            return coverage?.IdCobertura != null && coverage?.Descripcion != null ? new CoverageDto
            {
                IdCobertura = coverage.IdCobertura,
                Descripcion = coverage.Descripcion
            } : null;

        }

        public static Cobertura ToCoverageFromCreateDTO(this CreateCoverageRequestDto clientRequestDto)
        {
            return new Cobertura
            {
                Descripcion = clientRequestDto.Descripcion
            };
        }
    }
}
