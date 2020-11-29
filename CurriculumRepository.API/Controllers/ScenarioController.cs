using CurriculumRepository.API.Services.Scenario;
using CurriculumRepository.CORE.Data.Models.Scenario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {
        private readonly IScenarioService scenarioService;

        public ScenarioController(IScenarioService scenarioService)
        {
            this.scenarioService = scenarioService;
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLs([FromRoute] int id)
        {
            var result = await scenarioService.GetLs(id);
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpPost]
        public async Task<IActionResult> CreateLs([FromBody] LsBM model)
        {
            var result = await scenarioService.CreateLs(model);
            return Ok(result);
        }
    }
}
