using CurriculumRepository.CORE.Data.Models;
using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.StrategyMethodRepository
{
    public interface IStrategyMethodRepository
    {
        Task<IEnumerable<StrategyMethod>> GetStrategyMethods();
        Task<StrategyMethod> GetStrategyMethod(int id);
        Task<int> CreateStrategyMethod(StrategyMethodBM model);
    }
}
