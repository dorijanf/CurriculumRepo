using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LearningOutcomeSubjectRepository
{
    public interface ILearningOutcomeSubjectRepository
    {
        IEnumerable<LearningOutcomeSubject> AllLearningOutcomeSubjects { get; }
        Task<LearningOutcomeSubject> GetLearningOutcomeSubjectById(int Idls);
        Task<int> CreateLearningOutcomeSubject(List<string> los);
    }
}
