﻿using CurriculumRepository.API.Helpers;
using CurriculumRepository.API.Services;
using CurriculumRepository.CORE.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurriculumRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDTO model)
        {
            var result = await accountService.Authenticate(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserBM model)
        {
            var result = await accountService.Create(model);
            return Ok(result);
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var result = await accountService.GetUser(id);
            return Ok(result);
        }

        [Authorize(Roles = "administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await accountService.Delete(id);
            return Ok();
        }

        [Authorize(Roles = "administrator, korisnik")]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateUserBM model)
        {
            await accountService.Update(model);
            return Ok();
        }
    }
}
