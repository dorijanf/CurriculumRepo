using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaTeachingAidRepository
{
    public interface ILaTeachingAidRepository
    {
        Task<IEnumerable<TeachingAid>> GetTeachingAidsByLaId(int laid);
        Task CreateLaTeachingAid(int laId, int teachingAidId, bool? teachingAidUser);
        void RemoveLaTeachingAids(int id);
    }
}
