using System.ComponentModel.DataAnnotations;

namespace AuthService.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Nombre { get; set; } = string.Empty;
        public required string PrimerApellido { get; set; } = string.Empty;
        public required string SegundoApellido { get; set; } = string.Empty;
        public required string Rol { get; set; } 
    }
}
