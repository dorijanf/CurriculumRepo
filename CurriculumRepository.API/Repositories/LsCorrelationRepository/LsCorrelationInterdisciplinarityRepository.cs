using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using CurriculumRepository.Models.Repositories.LsCorrelationRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LsCorrelationRepository
{
    class LsCorrelationInterdisciplinarityRepository : ILsCorrelationInterdisciplinarityRepository
    {
        private readonly CurriculumDatabaseContext curriculumDatabaseContext;

        public LsCorrelationInterdisciplinarityRepository(CurriculumDatabaseContext curriculumDatabaseContext)
        {
            this.curriculumDatabaseContext = curriculumDatabaseContext;
        }

        public async Task CreateTeachingCorrelationSubjects(List<int> subjectIds, int lsId)
        {
            foreach (var subjectId in subjectIds)
            {
                var lsCorrelation = new LscorrelationInterdisciplinarity
                {
                    TeachingSubjectId = subjectId,
                    Lsid = lsId
                };
                curriculumDatabaseContext.LscorrelationInterdisciplinarity.Add(lsCorrelation);
            }
            await curriculumDatabaseContext.SaveChangesAsync();
        }

        public IEnumerable<LscorrelationInterdisciplinarity> GetLsCorrByLsId(int lsid)
        {
            var lscorr = curriculumDatabaseContext.LscorrelationInterdisciplinarity.Where(l => l.Lsid == lsid);
            return lscorr;
        }
    }
}
