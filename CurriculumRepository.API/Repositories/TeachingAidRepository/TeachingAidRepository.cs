using AutoMapper;
using CurriculumRepository.API.Extensions.Exceptions;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Data.Models;
using CurriculumRepository.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Repositories.TeachingAidRepository
{
    public class TeachingAidRepository : ITeachingAidRepository
    {
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;

        public TeachingAidRepository(CurriculumDatabaseContext context,
                                     IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> CreateTeachingAid(TeachingAidBM model)
        {
            var teachingAid = await context.TeachingAid.FirstOrDefaultAsync(x => x.TeachingAidName == model.TeachingAidName);
            if(teachingAid != null)
            {
                return teachingAid.IdteachingAid;
            }
            else
            {
                teachingAid = mapper.Map<TeachingAid>(model);
                context.TeachingAid.Add(teachingAid);
                await context.SaveChangesAsync();
                return teachingAid.IdteachingAid;
            }
        }

        public async Task<TeachingAid> GetTeachingAid(int id)
        {
            var teachingAid = await context.TeachingAid.FindAsync(id);

            if(teachingAid == null)
            {
                throw new NotFoundException($"Teaching aid with id {id} does not exist.");
            }

            return teachingAid;
        }

        public async Task<IEnumerable<TeachingAid>> GetTeachingAids()
        {
            return await context.TeachingAid.ToListAsync();
        }
    }
}
