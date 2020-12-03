using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.TeachingSubjectRepository
{
    public interface ITeachingSubjectRepository
    {
        Task<IEnumerable<TeachingSubject>> GetTeachingSubjects();
    }
}
