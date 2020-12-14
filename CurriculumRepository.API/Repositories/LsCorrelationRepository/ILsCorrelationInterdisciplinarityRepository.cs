using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.Models.Repositories.LsCorrelationRepository
{
    public interface ILsCorrelationInterdisciplinarityRepository
    {
        Task CreateTeachingCorrelationSubjects(List<int> subjectIds, int lsId);
        IEnumerable<LscorrelationInterdisciplinarity> GetLsCorrByLsId(int lsid);
        Task RemoveLsCorr(int lsId);
    }
}
