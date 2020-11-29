using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Models.Scenario;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.Scenario
{
    public interface IScenarioService
    {
        public Task<LsDTO> GetLs(int id);
        public Task<int> CreateLs(LsBM model);
    }
}
