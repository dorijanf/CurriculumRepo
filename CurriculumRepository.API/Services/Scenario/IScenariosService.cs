using CurriculumRepository.API.Extensions.Parameters;
using CurriculumRepository.API.Helpers;
using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Models.Scenario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.Scenario
{
    public interface IScenariosService
    {
        public Task<PagedList<LsListDTO>> GetScenarios(ScenarioParameters scenarioParameters);
        public Task<int> GetScenariosCount(ScenarioParameters scenarioParameters);
        public Task<LsDTO> GetScenario(int id);
        public Task<int> CreateScenario(LsBM model);
        public Task<int> DeleteScenario(int id);
        public Task<int> UpdateScenario(int id, LsBM model);
        public Task<IEnumerable<LsDTO>> GetUserScenarios(string id);
    }
}
