namespace PolizasService.Dtos.Client
{
    public class ClientDto
    {
        public string cedulaAsegurado { get; set; } = string.Empty;

        public string nombre { get; set; } = string.Empty;

        public string primerApellido { get; set; } = string.Empty;

        public string segundoApellido { get; set; } = string.Empty;

        public string tipoPersona { get; set; } = string.Empty;

        public DateOnly fechaNacimiento { get; set; }
    }
}
