using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.TeachingAidTypeRepository
{
    public class TeachingAidTypeRepository : ITeachingAidTypeRepository
    {
        private readonly CurriculumDatabaseContext context;

        public TeachingAidTypeRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TeachingAidType>> GetTeachingAidTypes()
        {
            return await context.TeachingAidType.ToListAsync();
        }
    }
}
