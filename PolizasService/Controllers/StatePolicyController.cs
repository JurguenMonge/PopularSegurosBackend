using Microsoft.AspNetCore.Mvc;
using PolizasService.Dtos.StatePolicy;
using PolizasService.Interfaces;
using PolizasService.Mappers;

namespace PolizasService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatePolicyController : ControllerBase
    {
        private readonly IStatePolicyRepository _statePolicyRepository;
        public StatePolicyController(IStatePolicyRepository statePolicyRepository)
        {
            _statePolicyRepository = statePolicyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var statePolicys = await _statePolicyRepository.GetAllAsync();
            var statePolicyDto = statePolicys.Select(statePolicys => statePolicys.ToStatePolicyDto());
            return Ok(statePolicyDto);
        }

        [HttpGet("{IdEstadoPoliza:int}")]
        public async Task<IActionResult> GetById([FromRoute] int IdEstadoPoliza)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var statePolicy = await _statePolicyRepository.GetByIdAsync(IdEstadoPoliza);
            if (statePolicy == null) return NotFound("El estado póliza no fue encontrado");
            return Ok(statePolicy);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStatePolicyRequestDto statePolicyDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var statePolicyModel = statePolicyDto.ToStatePolicyFromCreateDTO();
            await _statePolicyRepository.CreateAsync(statePolicyModel);
            return Ok("El estado póliza fue creado correctamente");
        }

        [HttpPut]
        [Route("{IdEstadoPoliza:int}")]
        public async Task<IActionResult> Update([FromRoute] int IdEstadoPoliza, [FromBody] CreateStatePolicyRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var statePolicy = await _statePolicyRepository.UpdateAsync(IdEstadoPoliza, updateDto);

            if (statePolicy == null)
            {
                return NotFound("El estado póliza que quieres actualizar no fue encontrado.");
            }

            return Ok("El estado póliza fue actualizado correctamente");
        }

        [HttpDelete]
        [Route("{IdEstadoPoliza:int}")]
        public async Task<IActionResult> Delete([FromRoute] int IdEstadoPoliza)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var statePolicy = await _statePolicyRepository.DeleteAsync(IdEstadoPoliza);
            if (statePolicy == null) return NotFound("El estado póliza que quieres eliminar no fue encontrado.");
            return NoContent();
        }
    }
}
