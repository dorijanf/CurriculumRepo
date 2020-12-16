using AutoMapper;
using CurriculumRepository.API.Configuration;
using CurriculumRepository.API.Extensions.Exceptions;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Data.Enums;
using CurriculumRepository.CORE.Data.Models.Account;
using CurriculumRepository.CORE.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurriculumRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly JwtSettings jwtSettings;
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountController(UserManager<User> userManager,
                                JwtSettings jwtSettings,
                                CurriculumDatabaseContext context,
                                IMapper mapper,
                                IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Authenticate user with username and password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Authenticated user entity</returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserDTO model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            // check if user with username exists
            if (user == null)
            {
                throw new BadRequestException("Username or password are incorrect.");
            }

            if (await userManager.CheckPasswordAsync(user, model.Password))
            {

                var token = await CreateTokenAsync(user);

                int userTypeId;
                if (await userManager.IsInRoleAsync(user, "administrator"))
                {
                    userTypeId = (int)UserTypeEnum.Administrator;
                }
                else
                {
                    userTypeId = (int)UserTypeEnum.Korisnik;
                }

                var result = new AuthenticationResponseDTO
                {
                    Id = user.Id,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Token = token.Token,
                    UserTypeId = userTypeId
                };

                return Ok(result);
            }
            throw new NotAuthorizedException("Username or password are incorrect.");
        }

        /// <summary>
        /// Creates a new user with data provided in RegisterUserBM
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Newly created user entity</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserBM model)
        {
            // username validation
            if (await userManager.FindByNameAsync(model.Username) != null)
            {
                throw new BadRequestException($"A user with username { model.Username } already exists.");
            }

            // TO DO: Implement image
            model.ProfilePicture = null;
            var user = mapper.Map<User>(model);
            user.SecurityStamp = Guid.NewGuid().ToString();
            user.RegistrationDate = DateTime.Now;
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "korisnik");
            }
            await context.SaveChangesAsync();

            return Ok();
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "administrator, korisnik")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"User {id} does not exist.");
            }

            int userTypeId;
            if (await userManager.IsInRoleAsync(user, "administrator"))
            {
                userTypeId = (int)UserTypeEnum.Administrator;
            }
            else
            {
                userTypeId = (int)UserTypeEnum.Korisnik;
            }

            var result = mapper.Map<UserDTO>(user);
            result.UserTypeId = userTypeId;
            return Ok(result);
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                await userManager.DeleteAsync(user);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("User not found.");
            }
            return Ok($"User {id} successfully deleted.");
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "administrator, korisnik")]
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateUserBM model)
        {
            var user = await userManager.FindByIdAsync(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            user = mapper.Map(model, user);
            await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
            
            return Ok(new { userId = user.Id });
        }

        /// <summary>
        /// Creates a security token used for authentication
        /// </summary>
        /// <param name="user"></param>
        /// <returns>TokenResult containing the token and expiration date</returns>
        private async Task<TokenResult> CreateTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var userRoles = await userManager.GetRolesAsync(user);
            claims.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(7);
            var token = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new TokenResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expires
            };
        }
    }
}
