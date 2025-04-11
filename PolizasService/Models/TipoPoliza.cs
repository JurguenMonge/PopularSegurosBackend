using System.ComponentModel.DataAnnotations;

namespace PolizasService.Models
{
    public class TipoPoliza
    {
        [Key]
        public int TipoPolizaId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Descripcion {  get; set; } = string.Empty;

        public ICollection<Poliza> Polizas { get; set; }
    }
}
