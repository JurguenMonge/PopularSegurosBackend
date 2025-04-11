using Microsoft.AspNetCore.Mvc;
using PolizasService.Dtos.Policy;
using PolizasService.Interfaces;
using PolizasService.Mappers;
using PolizasService.Repository;

namespace PolizasService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;
        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _policyService.GetAllAsync();
            if (!result.Success)
            {
                return StatusCode(result.StatusCode, result.Message);
            }

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PolicyRequestDto policyRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _policyService.CreatePolicyAsync(policyRequestDto);
            if (!result.Success)
            {
                return StatusCode(result.StatusCode, result.Message);  
            }

            return Ok(result.Message);
        }

        [HttpDelete]
        [Route("{idPoliza:int}")]
        public async Task<IActionResult> Delete([FromRoute] int idPoliza)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _policyService.DeleteAsync(idPoliza);
            if (!result.Success)
            {
                return StatusCode(result.StatusCode, result.Message);
            }

            return Ok(result.Message);

        }

        [HttpPut]
        [Route("{idPoliza:int}")]
        public async Task<IActionResult> Update([FromRoute] int idPoliza, [FromBody] PolicyRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _policyService.UpdateAsync(idPoliza, updateDto);

            if (!result.Success)
            {
                return StatusCode(result.StatusCode, result.Message);
            }

            return Ok(result.Message);
        }
    }


}
