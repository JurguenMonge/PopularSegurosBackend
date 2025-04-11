using ClientesService.Dtos;
using ClientesService.Models;

namespace ClientesService.Mappers
{
    public static class ClientMappers
    {
        public static ClientDto ToClientDto(this Cliente clientModel)
        {
            return new ClientDto
            {
                CedulaAsegurado = clientModel.CedulaAsegurado,
                Nombre = clientModel.Nombre,
                PrimerApellido = clientModel.PrimerApellido,
                SegundoApellido = clientModel.SegundoApellido,
                TipoPersona = clientModel.TipoPersona,
                FechaNacimiento = clientModel.FechaNacimiento
            };
        }

        public static Cliente ToClientFromCreateDTO(this CreateClientRequestDto clientRequestDto)
        {
            return new Cliente
            {
                CedulaAsegurado = clientRequestDto.CedulaAsegurado,
                Nombre = clientRequestDto.Nombre,
                PrimerApellido = clientRequestDto.PrimerApellido,
                SegundoApellido = clientRequestDto.SegundoApellido,
                TipoPersona = clientRequestDto.TipoPersona,
                FechaNacimiento = clientRequestDto.FechaNacimiento
            };
        }
    }
}
