using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.SelectData
{
    public interface ISelectDataService
    {
        Task<IEnumerable<TeachingSubject>> GetDropdownTeachingSubject();
        Task<IEnumerable<TeachingAidType>> GetDropdownTeachingAidType();
        Task<IEnumerable<TeachingAid>> GetDropdownTeachingAid();
        Task<IEnumerable<StrategyMethodType>> GetDropdownStrategyMethodType();
        Task<IEnumerable<StrategyMethod>> GetDropdownStrategyMethod();
        Task<IEnumerable<Latype>> GetDropdownLaType();
        Task<IEnumerable<Laperformance>> GetDropdownLaPerformance();
        Task<IEnumerable<Lacollaboration>> GetDropdownLaCollaboration();
        Task<IEnumerable<Keyword>> GetDropdownKeyword();
    }
}
