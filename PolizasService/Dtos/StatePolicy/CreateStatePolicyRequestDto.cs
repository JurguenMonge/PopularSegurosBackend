using System.ComponentModel.DataAnnotations;

namespace PolizasService.Dtos.StatePolicy
{
    public class CreateStatePolicyRequestDto
    {
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [MaxLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;
    }
}
