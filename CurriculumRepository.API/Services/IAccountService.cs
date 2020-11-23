using CurriculumRepository.API.Models;
using CurriculumRepository.CORE.Data.Models;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponseDTO> Authenticate(AuthenticateUserDTO model);
        Task<User> Create(RegisterUserBM model);
        Task<UserDTO> GetUser(int id);
        Task Update(UpdateUserBM model);
        Task Delete(int id);
    }
}
