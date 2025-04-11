using AuthService.Dtos.User;
using AuthService.Models;

namespace AuthService.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto 
            { 
                Id = userModel.Id,
                Email = userModel.Email,
                Password = userModel.Password,
                Nombre = userModel.Nombre,
                PrimerApellido = userModel.PrimerApellido,
                SegundoApellido = userModel.SegundoApellido,
                Rol = userModel.Rol,
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Email = userDto.Email,
                Nombre = userDto.Nombre,
                PrimerApellido = userDto.PrimerApellido,
                SegundoApellido = userDto.SegundoApellido,
                Rol =  "Admin",
            };
        }
    }
}
