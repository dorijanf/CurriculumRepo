using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                learningOutcomeSubjectString += lo + "||";
            }
            LearningOutcomeSubject learningSubject= null;
            if((learningSubject = await curriculumDatabaseContext.LearningOutcomeSubject.FirstOrDefaultAsync(x => x.LearningOutcomeSubjectStatement == learningOutcomeSubjectString)) == null)
            {
                var learningOutcomeSubject = new LearningOutcomeSubject { LearningOutcomeSubjectStatement = learningOutcomeSubjectString };
                curriculumDatabaseContext.LearningOutcomeSubject.Add(learningOutcomeSubject);
                await curriculumDatabaseContext.SaveChangesAsync();
                return learningOutcomeSubject.IdlearningOutcomeSubject;
            }
            else
            {
                return learningSubject.IdlearningOutcomeSubject;
            }
        }

        public async Task<LearningOutcomeSubject> GetLearningOutcomeSubjectById(int Idlearningoutcomesubject)
        {
            return await curriculumDatabaseContext.LearningOutcomeSubject
                .FirstOrDefaultAsync(l => l.IdlearningOutcomeSubject == Idlearningoutcomesubject);
        }
    }
}
