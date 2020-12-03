using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaStrategyMethodRepository
{
    public class LaStrategyMethodRepository : ILaStrategyMethodRepository
    {
        private readonly CurriculumDatabaseContext context;

        public LaStrategyMethodRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }

        public async Task CreateLaStrategyMethod(int laId, int strategyMethodId)
        {
            var laStrategyMethod = new LastrategyMethod
            {
                Laid = laId,
                StrategyMethodId = strategyMethodId
            };

            context.LastrategyMethod.Add(laStrategyMethod);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StrategyMethod>> GetLaStrategyMethodByLaId(int laid)
        {
            var laStrategyMethods = context.LastrategyMethod.Where(x => x.Laid == laid);
            List<StrategyMethod> strategyMethods = null;
            foreach (var strategyMethod in laStrategyMethods)
            {
                strategyMethods.Add(await context.StrategyMethod.FindAsync(strategyMethod.IdlastrategyMethod));
            }
            return strategyMethods;
        }

        public void RemoveLaStrategyMethods(int laId)
        {
            var laStrategyMethods = context.LastrategyMethod.Where(x => x.Laid == laId);
            context.RemoveRange(laStrategyMethods);
            context.SaveChanges();
        }
    }
}
