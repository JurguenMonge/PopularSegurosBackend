using System.ComponentModel.DataAnnotations;

namespace PolizasService.Dtos.Policy
{
    public class PolicyRequestDto
    {
        [Required(ErrorMessage = "El número de póliza es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El número de póliza no puede tener más de 50 caracteres.")]
        public string NumeroPoliza { get; set; }
        [Required(ErrorMessage = "El tipo de póliza es obligatorio.")]
        public string TipoPolizaDescripcion { get; set; }
        [Required(ErrorMessage = "La cobertura es obligatoria.")]
        public string CoberturaDescripcion { get; set; }
        [Required(ErrorMessage = "La estado de la póliza es obligatorio.")]
        public string EstadoPolizaDescripcion { get; set; }

        [Required(ErrorMessage = "El monto asegurado es obligatorio.")]
        public decimal MontoAsegurado { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateOnly FechaVencimiento { get; set; }

        [Required(ErrorMessage = "La fecha de emisión es obligatoria.")]
        public DateOnly FechaEmision { get; set; }

        [Required(ErrorMessage = "La prima es obligatoria.")]
        public decimal Prima { get; set; }

        [Required(ErrorMessage = "El periodo es obligatorio.")]
        public DateOnly Periodo { get; set; }

        [Required(ErrorMessage = "La fecha de inclusion es obligatoria.")]
        public DateOnly FechaInclusion { get; set; }
        [Required(ErrorMessage = "La aseguradora es obligatoria.")]
        [MaxLength(100, ErrorMessage = "La aseguradora no puede tener más de 100 caracteres.")]
        public string Aseguradora { get; set; }
        [Required(ErrorMessage = "La cédula es obligatoria.")]
        public string CedulaAsegurado { get; set; } = string.Empty;
    }
}
