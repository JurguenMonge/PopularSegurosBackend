using System.ComponentModel.DataAnnotations;

namespace ClientesService.Dtos
{
    public class ClientDto
    {
        public string CedulaAsegurado { get; set; } = string.Empty;
    
        public string Nombre { get; set; } = string.Empty;
      
        public string PrimerApellido { get; set; } = string.Empty;
      
        public string SegundoApellido { get; set; } = string.Empty;
       
        public string TipoPersona { get; set; } = string.Empty;
       
        public DateOnly FechaNacimiento { get; set; }
    }
}
