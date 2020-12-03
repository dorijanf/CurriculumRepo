using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaTypeRepository
{
    public interface ILaTypeRepository
    {
        Task<IEnumerable<Latype>> GetLatypes();
    }
}
