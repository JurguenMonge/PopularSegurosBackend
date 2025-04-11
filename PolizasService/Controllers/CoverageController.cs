using Microsoft.AspNetCore.Mvc;
using PolizasService.Dtos.Coverage;
using PolizasService.Interfaces;
using PolizasService.Mappers;

namespace PolizasService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverageController : ControllerBase
    {
        private readonly ICoverageRepository _coverageRepository;
        public CoverageController(ICoverageRepository coverageRepository)
        { 
            _coverageRepository = coverageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var coverages = await _coverageRepository.GetAllAsync();
            var coverageDto = coverages.Select(coverages => coverages.ToCoverageDto());
            return Ok(coverageDto);
        }

        [HttpGet("{IdCobertura:int}")]
        public async Task<IActionResult> GetById([FromRoute] int IdCobertura)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var coverage = await _coverageRepository.GetByIdAsync(IdCobertura);
            if (coverage == null) return NotFound("La cobertura no fue encontrada");
            return Ok(coverage);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCoverageRequestDto coverageDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var coverageModel = coverageDto.ToCoverageFromCreateDTO();
            await _coverageRepository.CreateAsync(coverageModel);
            return Ok("La cobertura fue creada correctamente");
        }

        [HttpPut]
        [Route("{IdCobertura:int}")]
        public async Task<IActionResult> Update([FromRoute] int IdCobertura, [FromBody] CreateCoverageRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var coverage = await _coverageRepository.UpdateAsync(IdCobertura, updateDto);

            if (coverage == null)
            {
                return NotFound("La cobertura que quieres actualizar no fue encontrada.");
            }

            return Ok("La cobertura fue actualizada correctamente");
        }

        [HttpDelete]
        [Route("{IdCobertura:int}")]
        public async Task<IActionResult> Delete([FromRoute] int IdCobertura)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var coverage = await _coverageRepository.DeleteAsync(IdCobertura);
            if (coverage == null) return NotFound("La cobertura que quieres eliminar no fue encontrada.");
            return NoContent();
        }

    }
}
