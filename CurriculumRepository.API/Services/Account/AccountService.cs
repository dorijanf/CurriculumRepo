using AutoMapper;
using CurriculumRepository.API.Configuration;
using CurriculumRepository.CORE.Data.Enums;
using CurriculumRepository.CORE.Data.Models.Account;
using CurriculumRepository.API.Extensions.Exceptions;
using Microsoft.AspNetCore.Http;
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
using CurriculumRepository.CORE.Entities;
using CurriculumRepository.CORE.Data;

namespace CurriculumRepository.API.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;
        private readonly JwtSettings jwtSettings;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<AccountService> logger;

        public AccountService(CurriculumDatabaseContext context,
                              IMapper mapper,
                              JwtSettings jwtSettings,
                              IHttpContextAccessor httpContextAccessor,
                              ILogger<AccountService> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.jwtSettings = jwtSettings;
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        public async Task<UserDTO> GetUser(int id)
        {
            var user = await context.User.FindAsync(id);
            return mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Authenticate user with username and password
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Authenticated user entity</returns>
        public async Task<AuthenticationResponseDTO> Authenticate(AuthenticateUserDTO model)
        {
            var user = await context.User.SingleOrDefaultAsync(x => x.Username == model.Username);

            // check if user with username exists
            if (user == null)
            {
                throw new BadRequestException("Username or password are incorrect.");
            }

            // check if password is correct
            if (!VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new BadRequestException($"Username or password are incorrect.");
            }

            var token = CreateTokenAsync(user);

            logger.LogInformation($"User with ID: { user.Iduser } successfully authenticated.");

            // authentication successful
            return new AuthenticationResponseDTO
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Token = token.Result.Token,
                userTypeId = user.UserTypeId
            };
        }

        /// <summary>
        /// Creates a new user with data provided in RegisterUserBM
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Newly created user entity</returns>
        public async Task<int> Create(RegisterUserBM model)
        {
            // username validation
            if (await context.User.AnyAsync(x => x.Username == model.Username))
            {
                throw new BadRequestException($"A user with username { model.Username } already exists.");
            }

            // email validation
            if (await context.User.AnyAsync(x => x.Email == model.Email))
            {
                throw new BadRequestException($"A user with email { model.Email } already exists.");
            }

            CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // TO DO: Implement image
            model.ProfilePicture = null;
            var user = mapper.Map<User>(model);
            user.UserTypeId = (int) UserTypeEnum.Korisnik;
            user.RegistrationDate = DateTime.Now;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            context.User.Add(user);
            await context.SaveChangesAsync();
            logger.LogInformation($"User { user.Username } successfully created.");

            return user.Iduser;
        }

        /// <summary>
        /// Deleted a user with provided id
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(int id)
        {
            var user = await context.User.FindAsync(id);

            if (user != null)
            {
                context.User.Remove(user);
                await context.SaveChangesAsync();
                logger.LogInformation($"User { user.Username } successfully deleted.");
            }
            else
            {
                throw new NotFoundException("User not found.");
            }
        }

        /// <summary>
        /// Updates an existing user with data provided in UpdateUserBM
        /// </summary>
        /// <param name="model"></param>
        public async Task<int> Update(UpdateUserBM model)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.Iduser.ToString() == httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            if (await context.User.AnyAsync(x => x.Email == model.Email))
            {
                throw new BadRequestException($"Email {model.Email} is already taken.");
            }

            if(!string.IsNullOrWhiteSpace(model.Password))
            {
                CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            user = mapper.Map(model, user);
            await context.SaveChangesAsync();
            logger.LogInformation($"User { user.Username } successfully updated.");
            return user.Iduser;
        }

        /// <summary>
        /// Creates a new password hash using the SHA512 hash function
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        /// <summary>
        /// Verifies the password hash 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
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
                new Claim(ClaimTypes.NameIdentifier, user.Iduser.ToString())
            };
            var userType = await context.UserType.FindAsync(user.UserTypeId);
            var userRoles = new List<string> { userType.UserTypeName };
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
