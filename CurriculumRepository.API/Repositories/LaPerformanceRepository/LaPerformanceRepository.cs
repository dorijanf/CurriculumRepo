using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaPerformanceRepository
{
    public class LaPerformanceRepository : ILaPerformanceRepository
    {
        private readonly CurriculumDatabaseContext context;

        public LaPerformanceRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Laperformance>> GetLaperformances()
        {
            return await context.Laperformance.ToListAsync();
        }
    }
}
