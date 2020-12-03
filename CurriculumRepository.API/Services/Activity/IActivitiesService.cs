using CurriculumRepository.CORE.Data.Models.Activity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.Activity
{
    public interface IActivitiesService
    {
        Task<List<LaDTO>> GetActivities(int id);
        Task<LaDTO> GetActivity(int activityId);
        Task<int> UpdateActivity(int scenarioId, int activityId, UpdateLaBM model); 
        Task<int> CreateActivity(int scenarioId, LaBM model);
        Task<int> DeleteActivity(int scenarioId, int activityId);
    }
}
