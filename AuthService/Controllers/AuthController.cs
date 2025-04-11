using AuthService.Data;
using AuthService.Dtos.User;
using AuthService.Interfaces;
using AuthService.Mappers;
using AuthService.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthHelper _authHelper;
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository, AuthHelper authHelper)
        {
            _authRepository = authRepository;
            _authHelper = authHelper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _authRepository.GetByEmailAsync(userRequestDto.Email) != null) return BadRequest("El correo electronico ya está registrado.");

            var userModel = userRequestDto.ToUserFromCreateDTO();
            userModel.Password = _authHelper.EncriptarPassword(userRequestDto.Password);

            await _authRepository.CreateAsync(userModel);
            return Ok("Usuario registrado con éxito");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _authRepository.GetByEmailAsync(loginRequestDto.Email);

            if (user == null)
                return Unauthorized("Credenciales inválidas");

            var isValidPassword = _authHelper.VerificarPassword(user.Password, loginRequestDto.Password);

            if (!isValidPassword)
                return Unauthorized("Credenciales inválidas");

            var token = _authHelper.GenerateJwtToken(user);

            return Ok(new
            {
                message = "Inicio de sesión exitoso",
                Nombre = $"{user.Nombre} {user.PrimerApellido} {user.SegundoApellido}",
                user.Rol,
                token
            });
        }
    }
}
