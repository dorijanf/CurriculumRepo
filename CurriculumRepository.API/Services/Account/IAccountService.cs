using CurriculumRepository.API.Models;
using CurriculumRepository.CORE.Data.Models.Account;
using CurriculumRepository.CORE.Entities;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.Account
{
    public interface IAccountService
    {
        Task<AuthenticationResponseDTO> Authenticate(AuthenticateUserDTO model);
        Task<int> Create(RegisterUserBM model);
        Task<UserDTO> GetUser(int id);
        Task<int> Update(UpdateUserBM model);
        Task Delete(int id);
    }
}
