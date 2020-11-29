using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LearningOutcomeSubjectRepository
{
    class LearningOutcomeSubjectRepository : ILearningOutcomeSubjectRepository
    {
        private readonly CurriculumDatabaseContext curriculumDatabaseContext;

        public LearningOutcomeSubjectRepository(CurriculumDatabaseContext curriculumDatabaseContext)
        {
            this.curriculumDatabaseContext = curriculumDatabaseContext;
        }

        public IEnumerable<LearningOutcomeSubject> AllLearningOutcomeSubjects
        {
            get
            {
                return curriculumDatabaseContext.LearningOutcomeSubject;
            }
        }

        public async Task<int> CreateLearningOutcomeSubject(List<string> los)
        {
            var learningOutcomeSubjectString = "";
            foreach (var lo in los)
            {
                learningOutcomeSubjectString = lo + "\n";
            }
            var learningOutcomeCt = new LearningOutcomeCt { LearningOutcomeCtstatement = learningOutcomeSubjectString };
            curriculumDatabaseContext.LearningOutcomeCt.Add(learningOutcomeCt);
            await curriculumDatabaseContext.SaveChangesAsync();
            return learningOutcomeCt.IdlearningOutcomeCt;
        }

        public async Task<LearningOutcomeSubject> GetLearningOutcomeSubjectById(int Idlearningoutcomesubject)
        {
            return await curriculumDatabaseContext.LearningOutcomeSubject
                .FirstOrDefaultAsync(l => l.IdlearningOutcomeSubject == Idlearningoutcomesubject);
        }
    }
}
