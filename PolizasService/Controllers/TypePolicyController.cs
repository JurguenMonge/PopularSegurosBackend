using Microsoft.AspNetCore.Mvc;
using PolizasService.Dtos.TypePolicy;
using PolizasService.Interfaces;
using PolizasService.Mappers;

namespace PolizasService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePolicyController : ControllerBase
    {
        private readonly ITypePolicyRepository _typePolicyRepository; 
        public TypePolicyController(ITypePolicyRepository typePolicyRepository)
        {
            _typePolicyRepository = typePolicyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var typePolicys = await _typePolicyRepository.GetAllAsync();
            var typePolicyDto = typePolicys.Select(typePolicys => typePolicys.ToTypePolicyDto());
            return Ok(typePolicyDto);
        }

        [HttpGet("{TipoPolizaId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int TipoPolizaId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var typePolicy = await _typePolicyRepository.GetByIdAsync(TipoPolizaId);
            if (typePolicy == null) return NotFound("El tipo de póliza no fue encontrado");
            return Ok(typePolicy);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTypePolicyRequestDto typePolicyRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var typePolicyModel = typePolicyRequestDto.ToTypePolicyFromCreateDTO();
            await _typePolicyRepository.CreateAsync(typePolicyModel);
            return Ok("El tipo póliza fue creado correctamente");
        }

        [HttpPut]
        [Route("{TipoPolizaId:int}")]
        public async Task<IActionResult> Update([FromRoute] int TipoPolizaId, [FromBody] CreateTypePolicyRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var typePolicy = await _typePolicyRepository.UpdateAsync(TipoPolizaId, updateDto);

            if (typePolicy == null)
            {
                return NotFound("El tipo de póliza que quieres actualizar no fue encontrado.");
            }

            return Ok("El tipo de póliza fue actualizado correctamente");
        }

        [HttpDelete]
        [Route("{TipoPolizaId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int TipoPolizaId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var typePolicy = await _typePolicyRepository.DeleteAsync(TipoPolizaId);
            if (typePolicy == null) return NotFound("El tipo póliza que quieres eliminar no fue encontrado.");
            return NoContent();
        }
    }
}
