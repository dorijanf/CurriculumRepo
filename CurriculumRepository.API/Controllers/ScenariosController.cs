using CurriculumRepository.API.Extensions.Parameters;
using CurriculumRepository.API.Services.Scenario;
using CurriculumRepository.CORE.Data.Models.Scenario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenariosController : ControllerBase
    {
        private readonly IScenariosService scenariosService;

        public ScenariosController(IScenariosService scenariosService)
        {
            this.scenariosService = scenariosService;
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpGet]
        public async Task<IActionResult> GetScenarios([FromQuery] ScenarioParameters scenarioParameters)
        {
            var result = await scenariosService.GetScenarios(scenarioParameters);
            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("count")]
        public async Task<IActionResult> GetScenariosCount([FromQuery] ScenarioParameters scenarioParameters)
        {
            var result = await scenariosService.GetScenariosCount(scenarioParameters);
            return Ok(new { scenariosCount = result });
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScenario([FromRoute] int id)
        {
            var result = await scenariosService.GetScenario(id);
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpPost]
        public async Task<IActionResult> CreateScenario([FromBody] LsBM model)
        {
            var result = await scenariosService.CreateScenario(model);
            return Ok(new { scenarioId = result });
        }

        [Authorize(Roles = "korisnik")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScenario([FromRoute] int id)
        {
            var result = await scenariosService.DeleteScenario(id);
            return Ok($"Scenario {result} successfully deleted.");
        }

        [Authorize(Roles = "korisnik")]
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateScenario([FromRoute] int id, [FromBody] LsBM model)
        {
            var result = await scenariosService.UpdateScenario(id, model);
            return Ok($"Scenario {result} successfully updated.");
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserScenarios([FromRoute] string userId)
        {
            var result = await scenariosService.GetUserScenarios(userId);
            return Ok(result);
        }
    }
}
