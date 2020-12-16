using CurriculumRepository.API.Services.Activity;
using CurriculumRepository.CORE.Data.Models.Activity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Controllers
{
    [Route("api/scenarios/{scenarioId}/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
            this.activitiesService = activitiesService;
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpGet("{activityId}")]
        public async Task<IActionResult> GetActivity([FromRoute] int scenarioId, [FromRoute] int activityId)
        {
            var result = await activitiesService.GetActivity(scenarioId, activityId);
            return Ok(result);
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpGet]
        public async Task<IActionResult> GetActivities([FromRoute] int scenarioId)
        {
            var result = await activitiesService.GetActivities(scenarioId);
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromRoute] int scenarioId, [FromBody] LaBM model) 
        {
            var result = await activitiesService.CreateActivity(scenarioId, model);
            return Ok(new { activityId = result });
        }

        [Authorize(Roles = "korisnik")]
        [HttpDelete("{activityId}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] int scenarioId, [FromRoute] int activityId)
        {
            var result = await activitiesService.DeleteActivity(scenarioId, activityId);
            return Ok(new { activityId = result });
        }

        [Authorize(Roles = "korisnik")]
        [HttpPatch("{activityId}")]
        public async Task<IActionResult> UpdateActivity([FromRoute] int scenarioId, [FromRoute] int activityId, [FromBody] LaBM model)
        {
            var result = await activitiesService.UpdateActivity(scenarioId, activityId, model);
            return Ok(new { activityId = result });
        }
    }
}
