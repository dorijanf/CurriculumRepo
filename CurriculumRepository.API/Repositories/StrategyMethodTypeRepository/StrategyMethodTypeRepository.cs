using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.StrategyMethodTypeRepository
{
    public class StrategyMethodTypeRepository : IStrategyMethodTypeRepository
    {
        private readonly CurriculumDatabaseContext context;

        public StrategyMethodTypeRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<StrategyMethodType>> GetStrategyMethodTypes()
        {
            return await context.StrategyMethodType.ToListAsync();
        }
    }
}
