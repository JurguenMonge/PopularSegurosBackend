using System.ComponentModel.DataAnnotations;

namespace ClientesService.Dtos
{
    public class CreateClientRequestDto
    {
        [Required]
        [MaxLength(20)]
        public required string CedulaAsegurado { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [Required]
        public required string PrimerApellido { get; set; }
        [Required]
        public required string SegundoApellido { get; set; }
        [Required]
        public required string TipoPersona { get; set; }
        [Required]
        public required DateOnly FechaNacimiento { get; set; }
    }
}
