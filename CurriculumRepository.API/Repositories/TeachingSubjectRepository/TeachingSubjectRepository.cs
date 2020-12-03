using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.TeachingSubjectRepository
{
    public class TeachingSubjectRepository : ITeachingSubjectRepository
    {
        private readonly CurriculumDatabaseContext context;

        public TeachingSubjectRepository(CurriculumDatabaseContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<TeachingSubject>> GetTeachingSubjects()
        {
            return await context.TeachingSubject.ToListAsync();
        }
    }
}
