using CurriculumRepository.CORE.Data.Models.Activity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.Activity
{
    public interface IActivityService
    {
        Task<List<LaDTO>> GetActivities(int id);
    }
}
