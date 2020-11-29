using AutoMapper;
using CurriculumRepository.API.Configuration;
using CurriculumRepository.API.Extensions.Exceptions;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Data.Models.Activity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.Activity
{
    public class ActivityService : IActivityService
    {
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<ActivityService> logger;

        public ActivityService(CurriculumDatabaseContext context,
                      IMapper mapper,
                      IHttpContextAccessor httpContextAccessor,
                      ILogger<ActivityService> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }
        public async Task<List<LaDTO>> GetActivities(int id)
        {
            var ls = await context.Ls.FindAsync(id);

            if (ls == null)
            {
                logger.LogError($"Scenario with id { id } not found.");
                throw new NotFoundException($"Learning scenario with id {id} not found.");
            }

            if (ls.LstypeId == 1 && httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value != ls.UserId.ToString())
            {
                logger.LogError($"Not authorized to view scenario with id { id }.");
                throw new NotAuthorizedException($"You are not authorized to view this resource.");
            }

            var lsla = context.Lsla.Where(x => x.Lsid == id)
                .Select(x => x.La);

            if (lsla == null)
            {
                logger.LogWarning($"Scenario with id { id } has no associated activities.");
                throw new NotFoundException("No activities could be found for that learning scenario.");
            }

            var laDTOs = new List<LaDTO>();

            foreach (var la in lsla)
            {
                var laDTO = mapper.Map<LaDTO>(la);
                laDTO.Laperformance = await context.Laperformance.FirstOrDefaultAsync(x => x.Idperformance == la.PerformanceId);
                laDTO.Latype = await context.Latype.FirstOrDefaultAsync(x => x.Idlatype == la.LatypeId);
                var strategyMethodIds = context.LastrategyMethod.Where(x => x.Laid == la.Idla)
                    .Select(x => x.IdlastrategyMethod);
                foreach (var strategyMethodId in strategyMethodIds)
                {
                    laDTO.LastrategyMethod.Add(await context.StrategyMethod.FindAsync(strategyMethodId));
                }
                laDTO.Lacollaboration = await context.Lacollaboration.FirstOrDefaultAsync(x => x.Idcollaboration == la.CooperationId);
                laDTO.LateachingAids = context.LateachingAid.Where(x => x.Laid == la.Idla).ToList();
                laDTOs.Add(mapper.Map<LaDTO>(la));
            }

            return laDTOs;
        }

        public async Task<LaDTO> GetActivity(int id)
        {
            var la = await context.La.FindAsync(id);

            if (la == null)
            {
                throw new NotFoundException("Learning activity not found.");
            }

            var ls = await context.Ls.FindAsync(la.Lsid);

            if (ls.LstypeId == 1 && httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value != ls.UserId.ToString())
            {
                throw new NotAuthorizedException("Learning scenario which contains this learning activity is private.");
            }

            return mapper.Map<LaDTO>(la);
        }
    }
}
