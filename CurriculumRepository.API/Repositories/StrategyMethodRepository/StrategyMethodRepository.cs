using AutoMapper;
using CurriculumRepository.API.Extensions.Exceptions;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Data.Models;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.StrategyMethodRepository
{
    public class StrategyMethodRepository : IStrategyMethodRepository
    {
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;

        public StrategyMethodRepository(CurriculumDatabaseContext context,
                                        IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StrategyMethod>> GetStrategyMethods()
        {
            return await context.StrategyMethod.ToListAsync();
        }

        public async Task<int> CreateStrategyMethod(StrategyMethodBM model)
        {
            var strategyMethod = await context.StrategyMethod
                .FirstOrDefaultAsync(x => x.StrategyMethodName == model.StrategyMethodName);
            if(strategyMethod != null)
            {
                return strategyMethod.IdstrategyMethod;
            }
            else
            {
                strategyMethod = mapper.Map<StrategyMethod>(model);
                context.StrategyMethod.Add(strategyMethod);
                await context.SaveChangesAsync();
            }
            return strategyMethod.IdstrategyMethod;
        }

        public async Task<StrategyMethod> GetStrategyMethod(int id)
        {
            var strategyMethod = await context.StrategyMethod.FindAsync(id);
            if(strategyMethod == null)
            {
                throw new NotFoundException($"Strategy method with id {id} not found.");
            }

            return strategyMethod;
        }
    }
}
