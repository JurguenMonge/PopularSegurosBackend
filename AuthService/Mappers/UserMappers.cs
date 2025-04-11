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
                Rol = userModel.Rol,
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Email = userDto.Email,
                Rol = userDto.Rol ?? "User",
            };
        }
    }
}
