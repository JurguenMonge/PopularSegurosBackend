namespace ClientesService.Dtos
{
    public class UpdateClientRequestDto
    {
        public string? CedulaAsegurado { get; set; } 

        public string? Nombre { get; set; } 

        public string? PrimerApellido { get; set; }

        public string? SegundoApellido { get; set; } 

        public string? TipoPersona { get; set; } 

        public DateOnly? FechaNacimiento { get; set; }
    }
}
