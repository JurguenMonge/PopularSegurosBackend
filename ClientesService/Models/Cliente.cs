using System.ComponentModel.DataAnnotations;

namespace ClientesService.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string CedulaAsegurado { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string PrimerApellido { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string SegundoApellido { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string TipoPersona { get; set; } = string.Empty;
        [Required]
        public DateOnly FechaNacimiento { get; set; }
        public bool EstaEliminado { get; set; } = false;
    }
}
