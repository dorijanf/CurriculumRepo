using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.LaTeachingAidRepository
{
    public class LaTeachingAidRepository : ILaTeachingAidRepository
    {
        private readonly CurriculumDatabaseContext context;

        public LaTeachingAidRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }

        public async Task CreateLaTeachingAid(int laId, int teachingAidId, bool? teachingAidUser)
        {
            var laTeachingAid = new LateachingAid
            {
                Laid = laId,
                TeachingAidId = teachingAidId,
                LateachingAidUser = teachingAidUser
            };

            context.LateachingAid.Add(laTeachingAid);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeachingAid>> GetTeachingAidsByLaId(int laid)
        {
            var laTeachingAid = context.LateachingAid.Where(x => x.Laid == laid);
            List<TeachingAid> teachingAids = null;
            foreach (var teachingAid in laTeachingAid)
            {
                teachingAids.Add(await context.TeachingAid.FindAsync(teachingAid.IdlateachingAid));
            }
            return teachingAids;
        }

        public async Task RemoveLaTeachingAids(int id)
        {
            var laTeachingAids = context.LateachingAid.Where(x => x.IdlateachingAid == id);
            context.RemoveRange(laTeachingAids);
            await context.SaveChangesAsync();
        }
    }
}
