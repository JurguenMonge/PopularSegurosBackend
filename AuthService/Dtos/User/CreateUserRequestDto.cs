namespace AuthService.Dtos.User
{
    public class CreateUserRequestDto
    {
        public required string Email { get; set; } 
        public required string Password { get; set; }
        public required string Rol { get; set; }
    }
}
