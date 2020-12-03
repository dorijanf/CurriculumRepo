using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LearningOutcomeCtRepository
{
    public class LearningOutcomeCtRepository : ILearningOutcomeCtRepository
    {
        private readonly CurriculumDatabaseContext curriculumDatabaseContext;

        public LearningOutcomeCtRepository(CurriculumDatabaseContext curriculumDatabaseContext)
        {
            this.curriculumDatabaseContext = curriculumDatabaseContext;
        }

        public IEnumerable<LearningOutcomeCt> AllLearningOutcomeCts
        {
            get
            {
                return curriculumDatabaseContext.LearningOutcomeCt;
            }
        }

        public async Task<int> CreateLearningOutcomeCts(List<string> loct)
        {
            var learningOutcomeCtString = "";
            foreach (var lo in loct)
            {
                learningOutcomeCtString += lo + "||";
            }

            LearningOutcomeCt learningSubject = null;
            if ((learningSubject = await curriculumDatabaseContext.LearningOutcomeCt.FirstOrDefaultAsync(x => x.LearningOutcomeCtstatement == learningOutcomeCtString)) == null)
            {
                var learningOutcomeCt = new LearningOutcomeCt { LearningOutcomeCtstatement = learningOutcomeCtString };
                curriculumDatabaseContext.LearningOutcomeCt.Add(learningOutcomeCt);
                await curriculumDatabaseContext.SaveChangesAsync();
                return learningOutcomeCt.IdlearningOutcomeCt;
            }
            else
            {
                return learningSubject.IdlearningOutcomeCt;
            }
        }

        public async Task<LearningOutcomeCt> GetLearningOutcomeCtById(int Idct)
        {
            return await curriculumDatabaseContext.LearningOutcomeCt.FirstOrDefaultAsync(c => c.IdlearningOutcomeCt == Idct);
        }
    }
}
