using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaCollaborationRepository
{
    public interface ILaCollaborationRepository
    {
        Task<IEnumerable<Lacollaboration>> GetLacollaborations();
    }
}
