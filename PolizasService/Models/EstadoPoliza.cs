using System.ComponentModel.DataAnnotations;

namespace PolizasService.Models
{
    public class EstadoPoliza
    {
        [Key]
        public int IdEstadoPoliza { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; } = string.Empty;

        public ICollection<Poliza> Polizas { get; set; }
    }
}
