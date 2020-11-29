using System.Collections.Generic;
using System.Threading.Tasks;
using CurriculumRepository.CORE.Entities;

namespace CurriculumRepository.API.Repositories.LearningOutcomeCtRepository
{
    public interface ILearningOutcomeCtRepository
    {
        IEnumerable<LearningOutcomeCt> AllLearningOutcomeCts { get; }
        Task<LearningOutcomeCt> GetLearningOutcomeCtById(int Idct);
        Task<int> CreateLearningOutcomeCts(List<string> loct);
    }
}
