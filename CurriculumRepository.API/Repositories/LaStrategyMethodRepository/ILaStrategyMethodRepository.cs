using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaStrategyMethodRepository
{
    public interface ILaStrategyMethodRepository
    {
        Task CreateLaStrategyMethod(int laId, int strategyMethodId);
        Task<IEnumerable<StrategyMethod>> GetLaStrategyMethodByLaId(int lsid);
        Task RemoveLaStrategyMethods(int laId);
    }
}
