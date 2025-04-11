using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolizasService.Models
{
    public class Poliza
    {
        [Key]
        public int IdPoliza { get; set; }
        [Required]
        [StringLength(50)]
        public string NumeroPoliza { get; set; }
        [Required] 
        [StringLength(20)]  
        public string CedulaAsegurado { get; set; }

        [ForeignKey("TipoPolizaId")] 
        public int TipoPolizaId { get; set; }
        public TipoPoliza TipoPoliza { get; set; }  

        [ForeignKey("CoberturaId")]  
        public int CoberturaId { get; set; }
        public Cobertura Cobertura { get; set; }  

        [ForeignKey("EstadoPolizaId")]  
        public int EstadoPolizaId { get; set; }
        public EstadoPoliza EstadoPoliza { get; set; } 

        [Range(0, double.MaxValue)]  
        public decimal MontoAsegurado { get; set; }

        [DataType(DataType.Date)] 
        public DateOnly FechaVencimiento { get; set; }

        [DataType(DataType.Date)]  
        public DateOnly FechaEmision { get; set; }

        [Range(0, double.MaxValue)]  
        public decimal Prima { get; set; }

        [DataType(DataType.Date)] 
        public DateOnly Periodo { get; set; }

        [DataType(DataType.Date)] 
        public DateOnly FechaInclusion { get; set; }

        [Required]  
        [StringLength(100)]
        public string Aseguradora { get; set; }
        public bool EstaEliminado { get; set; } = false;
    }
}
