using CurriculumRepository.API.Extensions.Exceptions;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LsLaRepository
{
    public class LsLaRepository : ILsLaRepository
    {
        private readonly CurriculumDatabaseContext context;

        public LsLaRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }
        public async Task CreateLsLa(int lsId, int laId)
        {
            if(await context.Ls.FindAsync(lsId) == null)
            {
                throw new NotFoundException($"Scenario {lsId} does not exist.");
            }

            if(await context.La.FindAsync(laId) == null)
            {
                throw new NotFoundException($"Activity {laId} does not exist");
            }

            var lsLa = new Lsla
            {
                Lsid = lsId,
                Laid = laId
            };

            await context.Lsla.AddAsync(lsLa);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<La>> GetLasByLsId(int lsId)
        {
            var lsLas = await context.Lsla.Where(x => x.Lsid == lsId).ToListAsync();

            var las = new List<La>();
            foreach (var lsLa in lsLas)
            {
                las.Add(await context.La.FindAsync(lsLa.Laid));
            }

            return las;
        }

        public async Task RemoveLsLa(int scenarioId, int activityId)
        {
            var lsLa = await context.Lsla.FirstOrDefaultAsync(x => x.Laid == activityId && x.Lsid == scenarioId);
            context.Lsla.Remove(lsLa);
            context.SaveChanges();
        }
    }
}
