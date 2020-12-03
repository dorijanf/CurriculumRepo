using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaPerformanceRepository
{
    public interface ILaPerformanceRepository
    {
        Task<IEnumerable<Laperformance>> GetLaperformances();
    }
}
