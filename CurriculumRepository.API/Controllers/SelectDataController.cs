using CurriculumRepository.API.Services.Activity;
using CurriculumRepository.API.Services.SelectData;
using CurriculumRepository.CORE.Data.Models.Activity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ISelectDataService selectDataService;

        public DataController(ISelectDataService selectDataService)
        {
            this.selectDataService = selectDataService;
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("teaching-subjects")]
        public async Task<IActionResult> GetTeachingSubjects()
        {
            var result = await selectDataService.GetDropdownTeachingSubject();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("teaching-aids")]
        public async Task<IActionResult> GetTeachingAids()
        {
            var result = await selectDataService.GetDropdownTeachingAid();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("teaching-aid-types")]
        public async Task<IActionResult> Get()
        {
            var result = await selectDataService.GetDropdownTeachingAidType();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("strategy-method-types")]
        public async Task<IActionResult> GetStrategyMethodTypes()
        {
            var result = await selectDataService.GetDropdownStrategyMethodType();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("strategy-methods")]
        public async Task<IActionResult> GetStrategyMethods()
        {
            var result = await selectDataService.GetDropdownStrategyMethod();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("la-types")]
        public async Task<IActionResult> GetLaTypes()
        {
            var result = await selectDataService.GetDropdownLaType();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("la-performances")]
        public async Task<IActionResult> GetLaPerformances()
        {
            var result = await selectDataService.GetDropdownLaPerformance();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("la-collaborations")]
        public async Task<IActionResult> GetLaCollaborations()
        {
            var result = await selectDataService.GetDropdownLaCollaboration();
            return Ok(result);
        }

        [Authorize(Roles = "korisnik")]
        [HttpGet("keywords")]
        public async Task<IActionResult> GetKeywords()
        {
            var result = await selectDataService.GetDropdownKeyword();
            return Ok(result);
        }
    }
}
