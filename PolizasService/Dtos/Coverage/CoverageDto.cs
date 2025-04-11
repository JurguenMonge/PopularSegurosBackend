using System.ComponentModel.DataAnnotations;

namespace PolizasService.Dtos.Coverage
{
    public class CoverageDto
    {
        public int IdCobertura { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}
