using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LsLaRepository
{
    public interface ILsLaRepository
    {
        public Task CreateLsLa(int lsId, int laId);
        public Task<IEnumerable<La>> GetLasByLsId(int lsId);
        public Task RemoveLsLa(int scenarioId, int activityId);
    }
}
