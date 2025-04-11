using PolizasService.Dtos.Client;

namespace PolizasService.Dtos.Policy
{
    public class PolicyDto
    {
        public int IdPoliza { get; set; }
        public string NumeroPoliza { get; set; }
        public string CedulaAsegurado { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string TipoPersona { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public int TipoPolizaId { get; set; }
        public string TipoPolizaDescripcion { get; set; }
        public int CoberturaId { get; set; }
        public string CoberturaDescripcion { get; set; }
        public int EstadoPolizaId { get; set; }
        public string EstadoPolizaDescripcion { get; set; }
        public decimal MontoAsegurado { get; set; }
        public DateOnly FechaVencimiento { get; set; }
        public DateOnly FechaEmision { get; set; }
        public decimal Prima { get; set; }
        public DateOnly Periodo { get; set; }
        public DateOnly FechaInclusion { get; set; }
        public string Aseguradora { get; set; }

        
    }
}
