using Microsoft.AspNetCore.Mvc;
using Student.Web.Api.Data;
using Student.Web.Api.Models;
using Student.Web.Api.Dto;

namespace Student.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradingController : ControllerBase
    {
        private readonly IGradingRepository _gradingRepository;

        public GradingController(IGradingRepository gradingRepository)
        {
            _gradingRepository = gradingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetGradings()
        {
            var gradings = await _gradingRepository.GetAllAsync();
            return Ok(gradings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrading(string id)
        {
            var grading = await _gradingRepository.GetById(id);
            if (grading == null)
                return NotFound();

            return Ok(grading);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrading([FromBody] Grading grading)
        {
            _gradingRepository.Add(grading);
            if (await _gradingRepository.SaveAllChangesAsync())
                return CreatedAtAction(nameof(GetGrading), new { id = grading.GradingId }, grading);

            return BadRequest("May Error ka!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrading(string id, [FromBody] Grading grading)
        {
            var existingGrading = await _gradingRepository.GetById(id);
            if (existingGrading == null)
                return NotFound();

            existingGrading.Grade = grading.Grade;
            existingGrading.Remarks = grading.Remarks;

            if (await _gradingRepository.SaveAllChangesAsync())
                return Ok(existingGrading);

            return BadRequest("May Error ka!");
        }

        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteGrading(string id)
{
    var grading = await _gradingRepository.GetById(id);
    if (grading == null)
        return NotFound();

    _gradingRepository.Delete(grading); // tawag Delete method

    if (await _gradingRepository.SaveAllChangesAsync())
        return NoContent();

    return BadRequest("Hindi na delete.");
}
    }
}