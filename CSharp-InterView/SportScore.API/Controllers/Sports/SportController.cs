using Microsoft.AspNetCore.Mvc;
using SportScore.API.Controllers.Sports.DataModel;
using SportScore.API.Controllers.Sports.Service;

namespace SportScore.API.Controllers.Sports
{
    [ApiController]
    [Route("api/[controller]")]
    public class SportController : ControllerBase
    {
        private readonly IMatchResultService _service;

        public SportController(IMatchResultService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAllMatches")]
        public IActionResult TestMessage()
        {
            var result = _service.ListAllMatchesAsync().ToList();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("SaveMatch")]
        public async Task<IActionResult> CheckAndSaveResult([FromBody] MatchResultDto dto)
        {

            if (string.IsNullOrEmpty(dto.Team1.Trim()) || string.IsNullOrEmpty(dto.Team2.Trim()))
            {
                throw new Exception("Team names should not be empty.");
            }

            if (dto.Sport == "Volleyball" && dto.Score.Split(',').Count() < 1)
            {
                throw new Exception("Atlease one match set needed.");
            }
            else if (dto.Sport == "Squash" && dto.Score.Split(',').Count() >= 3)
            {
                throw new Exception("Match result not found.");
            }
            var result = await _service.CheckAndSaveResultAsync(dto.Team1, dto.Team2,dto.Sport, dto.Score, dto.InputString);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMatchByID/{id}")]
        public async Task<IActionResult> GetMatchResultById(Guid id)
        {
            var result = await _service.GetMatchResultByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        [ActionName("DeleteMatchByID/{id}")]
        public async Task<IActionResult> DeleteMatchResultById(Guid id)
        {
            var success = await _service.DeleteMatchResultByIdAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}