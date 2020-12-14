using AutoMapper;
using CurriculumRepository.API.Extensions.Exceptions;
using CurriculumRepository.API.Repositories.LaStrategyMethodRepository;
using CurriculumRepository.API.Repositories.LaTeachingAidRepository;
using CurriculumRepository.API.Repositories.LsLaRepository;
using CurriculumRepository.API.Repositories.StrategyMethodRepository;
using CurriculumRepository.API.Repositories.TeachingAidRepository;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.CORE.Data.Models;
using CurriculumRepository.CORE.Data.Models.Activity;
using CurriculumRepository.CORE.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.Activity
{
    public class ActivitiesService : IActivitiesService
    {
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<ActivitiesService> logger;
        private readonly IStrategyMethodRepository strategyMethodRepository;
        private readonly ILaStrategyMethodRepository laStrategyMethodRepository;
        private readonly ITeachingAidRepository teachingAidRepository;
        private readonly ILaTeachingAidRepository laTeachingAidRepository;
        private readonly ILsLaRepository lsLaRepository;

        public ActivitiesService(CurriculumDatabaseContext context,
                      IMapper mapper,
                      IHttpContextAccessor httpContextAccessor,
                      ILogger<ActivitiesService> logger,
                      IStrategyMethodRepository strategyMethodRepository,
                      ILaStrategyMethodRepository laStrategyMethodRepository,
                      ITeachingAidRepository teachingAidRepository,
                      ILaTeachingAidRepository laTeachingAidRepository,
                      ILsLaRepository lsLaRepository)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
            this.strategyMethodRepository = strategyMethodRepository;
            this.laStrategyMethodRepository = laStrategyMethodRepository;
            this.teachingAidRepository = teachingAidRepository;
            this.laTeachingAidRepository = laTeachingAidRepository;
            this.lsLaRepository = lsLaRepository;
        }

        /// <summary>
        /// Creates a new activity for a scenario with a given id with data
        /// passed in a learning activity binding model
        /// </summary>
        /// <param name="scenarioId"></param>
        /// <param name="model"></param>
        /// <returns>Id of newly created learning activity</returns>
        public async Task<int> CreateActivity(int scenarioId, LaBM model)
        {
            var ls = await context.Ls.FindAsync(scenarioId);

            if(ls == null)
            {
                throw new NotFoundException("Learning scenario not found.");
            }

            if (ls.UserId.ToString() != httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                logger.LogError($"Not authorized to view scenario with id { scenarioId }");
                throw new NotAuthorizedException($"You are not authorized to view this resource.");
            }

            var la = mapper.Map<La>(model);
            ls.Lsduration += la.Laduration;
            context.Update(ls);
            await context.SaveChangesAsync();
            foreach (var strategyMethod in model.StrategyMethods)
            {
                var strategyMethodId = await strategyMethodRepository.CreateStrategyMethod(strategyMethod);
                await laStrategyMethodRepository.CreateLaStrategyMethod(la.Idla, strategyMethodId);
            }

            foreach (var teachingAid in model.LaTeachingAidUser)
            {
                var taId = await teachingAidRepository.CreateTeachingAid(teachingAid);
                await laTeachingAidRepository.CreateLaTeachingAid(la.Idla, taId, true);
            }

            foreach (var teachingAid in model.LaTeachingAidTeacher)
            {
                var taId = await teachingAidRepository.CreateTeachingAid(teachingAid);
                await laTeachingAidRepository.CreateLaTeachingAid(la.Idla, taId, false);
            }

            await lsLaRepository.CreateLsLa(ls.Idls, la.Idla);
            return la.Idla;
        }

        /// <summary>
        /// Deletes an activity from a scenario with a given id of the activity
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public async Task<int> DeleteActivity(int scenarioId, int activityId)
        {
            var ls = await context.Ls.FindAsync(scenarioId);

            if (ls == null)
            {
                throw new NotFoundException($"Scenario {scenarioId} does not exist.");
            }

            var la = await context.La.FindAsync(activityId);

            if (la == null)
            {
                throw new NotFoundException($"Learning activity with id {activityId} not found.");
            }
            context.La.Remove(la);
            await context.SaveChangesAsync();
            await lsLaRepository.RemoveLsLa(scenarioId, activityId);
            logger.LogInformation($"Activity {la.Idla} successfully deleted.");
            return la.Idla;
        }

        /// <summary>
        /// Updates a new activity for a given scenario with provided data in Update activity
        /// binding model. 
        /// </summary>
        /// <param name="scenarioId"></param>
        /// <param name="activityId"></param>
        /// <param name="model"></param>
        /// <returns>Id of newly updated activity</returns>
        public async Task<int> UpdateActivity(int scenarioId, int activityId, UpdateLaBM model)
        {
            var ls = await context.Ls.FindAsync(scenarioId);

            if (ls == null)
            {
                throw new NotFoundException($"Scenario {scenarioId} does not exist.");
            }

            if (ls.UserId.ToString() != httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                logger.LogError($"Not authorized to view scenario with id { scenarioId }");
                throw new NotAuthorizedException($"You are not authorized to view this resource.");
            }

            var la = await context.La.FindAsync(activityId);

            if (la == null)
            {
                throw new NotFoundException($"Scenario {scenarioId} does not exist.");
            }

            la = mapper.Map<La>(model);
            if(model.Laduration != null)
            {
                ls.Lsduration += model.Laduration;
            }

            await laStrategyMethodRepository.RemoveLaStrategyMethods(activityId);
            foreach (var strategyMethod in model.StrategyMethods)
            {
                var strategyMethodId = await strategyMethodRepository.CreateStrategyMethod(strategyMethod);
                await laStrategyMethodRepository.CreateLaStrategyMethod(la.Idla, strategyMethodId);
            }

            await laTeachingAidRepository.RemoveLaTeachingAids(activityId);
            foreach (var teachingAid in model.LaTeachingAidUser)
            {
                var taId = await teachingAidRepository.CreateTeachingAid(teachingAid);
                await laTeachingAidRepository.CreateLaTeachingAid(la.Idla, taId, true);
            }

            foreach (var teachingAid in model.LaTeachingAidTeacher)
            {
                var taId = await teachingAidRepository.CreateTeachingAid(teachingAid);
                await laTeachingAidRepository.CreateLaTeachingAid(la.Idla, taId, false);
            }

            logger.LogInformation($"Activity {la.Idla} successfully updated.");
            context.Update(la);
            context.Update(ls);
            await context.SaveChangesAsync();
            return la.Idla;
        }
        
        /// <summary>
        /// Retrieves all activites for a given learning scenario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of all activities for a scenario</returns>
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

                var laPerformance = await context.Laperformance.FirstOrDefaultAsync(x => x.Idperformance == la.PerformanceId);
                laDTO.Laperformance = laPerformance.PerformanceName;

                var laType = await context.Latype.FirstOrDefaultAsync(x => x.Idlatype == la.LatypeId);
                laDTO.Latype = laType.LatypeName;

                var laCollaboration = await context.Lacollaboration.FirstOrDefaultAsync(x => x.Idcollaboration == la.CooperationId);
                laDTO.Lacollaboration = laCollaboration.CollaborationName;

                var strategyMethodIds = context.LastrategyMethod.Where(x => x.Laid == la.Idla)
                    .Select(x => x.IdlastrategyMethod);
                foreach (var strategyMethodId in strategyMethodIds)
                {
                    var strategyMethod = await context.StrategyMethod.FirstOrDefaultAsync(x => x.IdstrategyMethod == strategyMethodId);
                    laDTO.StrategyMethods.Add(mapper.Map<StrategyMethodBM>(strategyMethod));
                }

                var teachingAidIds = context.LateachingAid.Where(x => x.Laid == la.Idla)
                    .Select(x => x.IdlateachingAid);
                foreach (var teachingAidId in teachingAidIds)
                {
                    var teachingAid = await context.TeachingAid.FirstOrDefaultAsync(x => x.IdteachingAid == teachingAidId);
                    laDTO.TeachingAids.Add(mapper.Map<TeachingAidBM>(teachingAid));
                }

                laDTOs.Add(mapper.Map<LaDTO>(la));
            }

            return laDTOs;
        }

        /// <summary>
        /// Retrieves an activity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Data transfer object containing activity information</returns>
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
