using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaCollaborationRepository
{
    public class LaCollaborationRepository : ILaCollaborationRepository
    {
        private readonly CurriculumDatabaseContext context;

        public LaCollaborationRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Lacollaboration>> GetLacollaborations()
        {
            return await context.Lacollaboration.ToListAsync();
        }
    }
}
