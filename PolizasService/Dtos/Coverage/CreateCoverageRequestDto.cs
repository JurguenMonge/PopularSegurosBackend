using System.ComponentModel.DataAnnotations;

namespace PolizasService.Dtos.Coverage
{
    public class CreateCoverageRequestDto
    {
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [MaxLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;
    }
}
