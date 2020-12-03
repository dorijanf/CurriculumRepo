using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaTypeRepository
{
    public class LaTypeRepository : ILaTypeRepository
    {
        private readonly CurriculumDatabaseContext context;

        public LaTypeRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Latype>> GetLatypes()
        {
            return await context.Latype.ToListAsync();
        }
    }
}
