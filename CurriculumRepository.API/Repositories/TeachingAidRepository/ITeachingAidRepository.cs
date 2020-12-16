using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using CurriculumRepository.CORE.Data.Models;

namespace CurriculumRepository.API.Repositories.TeachingAidRepository
{
    public interface ITeachingAidRepository
    {
        Task<IEnumerable<TeachingAid>> GetTeachingAids();
        Task<TeachingAid> GetTeachingAid(int id);
        Task<int> CreateTeachingAid(TeachingAid model);
    }
}
