using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using CurriculumRepository.Models.Repositories.LsCorrelationRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LsCorrelationRepository
{
    class LsCorrelationInterdisciplinarityRepository : ILsCorrelationInterdisciplinarityRepository
    {
        private readonly CurriculumDatabaseContext context;

        public LsCorrelationInterdisciplinarityRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }

        public async Task CreateTeachingCorrelationSubjects(List<int> subjectIds, int lsId)
        {
            foreach (var subjectId in subjectIds)
            {
                if ((context.LscorrelationInterdisciplinarity.Where(x => x.Lsid == lsId && x.TeachingSubjectId == subjectId) != null))
                {
                    var lsCorrelation = new LscorrelationInterdisciplinarity
                    {
                        TeachingSubjectId = subjectId,
                        Lsid = lsId
                    };
                    context.LscorrelationInterdisciplinarity.Add(lsCorrelation);
                }
            }
            await context.SaveChangesAsync();
        }

        public IEnumerable<LscorrelationInterdisciplinarity> GetLsCorrByLsId(int lsid)
        {
            var lscorr = context.LscorrelationInterdisciplinarity.Where(l => l.Lsid == lsid);
            return lscorr;
        }

        public async Task RemoveLsCorr(int lsId)
        {
            var lsCorr = context.LscorrelationInterdisciplinarity.Where(x => x.Lsid == lsId);
            context.RemoveRange(lsCorr);
            await context.SaveChangesAsync();
        }
    }
}
