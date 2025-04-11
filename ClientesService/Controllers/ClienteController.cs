using ClientesService.Dtos;
using ClientesService.Interfaces;
using ClientesService.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace ClientesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClienteController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var clients = await _clientRepository.GetAllAsync();
            var clientDto = clients.Select(clients => clients.ToClientDto());
            return Ok(clientDto);
        }

        [HttpGet("{CedulaAsegurado}")]
        public async Task<IActionResult> GetById([FromRoute] string CedulaAsegurado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var client = await _clientRepository.GetByIdAsync(CedulaAsegurado);
            if (client == null) return NotFound("El cliente no fue encontrado");
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientRequestDto clientDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var clientExist = await _clientRepository.GetByIdAsync(clientDto.CedulaAsegurado);
            if(clientExist != null) return BadRequest("El cliente que estas creando ya existe");

            var clientModel = clientDto.ToClientFromCreateDTO();
            await _clientRepository.CreateAsync(clientModel);
            return Ok("El cliente fue creado correctamente");
        }

        [HttpPut]
        [Route("{CedulaAsegurado}")]
        public async Task<IActionResult> Update([FromRoute] string CedulaAsegurado, [FromBody] UpdateClientRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var person = await _clientRepository.UpdateAsync(CedulaAsegurado, updateDto);

            if (person == null)
            {
                return NotFound("La persona que quieres actualizar no fue encontrada.");
            }

            return Ok("La persona fue actualizada correctamente");
        }

        [HttpDelete]
        [Route("{CedulaAsegurado}")]
        public async Task<IActionResult> Delete([FromRoute] string CedulaAsegurado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var personModel = await _clientRepository.DeleteAsync(CedulaAsegurado);
            if (personModel == null) return NotFound("La persona que quieres eliminar no fue encontrada.");
            return NoContent();
        }
    }
}
