using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.Models.Repositories.LsCorrelationRepository
{
    public interface ILsCorrelationInterdisciplinarityRepository
    {
        public Task CreateTeachingCorrelationSubjects(List<int> subjectIds, int lsId);
        public IEnumerable<LscorrelationInterdisciplinarity> GetLsCorrByLsId(int lsid);
    }
}
