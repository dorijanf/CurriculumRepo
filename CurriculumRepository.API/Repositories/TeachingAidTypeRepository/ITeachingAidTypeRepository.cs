using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.TeachingAidTypeRepository
{
    public interface ITeachingAidTypeRepository
    {
        Task<IEnumerable<TeachingAidType>> GetTeachingAidTypes();
    }
}
