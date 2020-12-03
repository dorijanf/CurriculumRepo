using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.StrategyMethodTypeRepository
{
    public interface IStrategyMethodTypeRepository
    {
        Task<IEnumerable<StrategyMethodType>> GetStrategyMethodTypes();
    }
}
