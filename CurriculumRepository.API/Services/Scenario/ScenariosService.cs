using AutoMapper;
using CurriculumRepository.CORE.Data.Models.Scenario;
using CurriculumRepository.API.Extensions.Exceptions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Linq;
using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.API.Services.Activity;
using System;
using CurriculumRepository.CORE.Entities;
using CurriculumRepository.CORE.Data;
using CurriculumRepository.API.Repositories.KeywordRepository;
using CurriculumRepository.Models.Repositories.LsCorrelationRepository;
using CurriculumRepository.API.Repositories.LearningOutcomeCtRepository;
using CurriculumRepository.API.Repositories.LearningOutcomeSubjectRepository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CurriculumRepository.CORE.Data.Enums;
using CurriculumRepository.API.Extensions.Parameters;
using CurriculumRepository.API.Helpers;
using CurriculumRepository.API.Helpers.Sort;

namespace CurriculumRepository.API.Services.Scenario
{
    public class ScenariosService : IScenariosService
    {
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<ScenariosService> logger;
        private readonly IActivitiesService activityService;
        private readonly ILearningOutcomeCtRepository learningOutcomeCtRepository;
        private readonly ILearningOutcomeSubjectRepository learningOutcomeSubjectRepository;
        private readonly IKeywordRepository keywordRepository;
        private readonly ILsCorrelationInterdisciplinarityRepository lsCorrelationRepository;
        private readonly ISort<Ls> sortService;

        public ScenariosService(CurriculumDatabaseContext context,
                              IMapper mapper,
                              IHttpContextAccessor httpContextAccessor,
                              ILogger<ScenariosService> logger,
                              IActivitiesService activityService,
                              ILearningOutcomeCtRepository learningOutcomeCtRepository,
                              ILearningOutcomeSubjectRepository learningOutcomeSubjectRepository,
                              IKeywordRepository keywordRepository,
                              ILsCorrelationInterdisciplinarityRepository lsCorrelationRepository,
                              ISort<Ls> sortService
                              )
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
            this.activityService = activityService;
            this.learningOutcomeCtRepository = learningOutcomeCtRepository;
            this.learningOutcomeSubjectRepository = learningOutcomeSubjectRepository;
            this.keywordRepository = keywordRepository;
            this.lsCorrelationRepository = lsCorrelationRepository;
            this.sortService = sortService;
        }

        /// <summary>
        /// Creates new Ls (learning scenario) and its corresponding 
        /// objects such as keywords, teachingcorrelationsubjects and learningoutcomes.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Id of newly created scenario</returns>
        public async Task<int> CreateScenario(LsBM model)
        {
            var ls = mapper.Map<Ls>(model);
            ls.UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ls.LearningOutcomeCtid = await learningOutcomeCtRepository.CreateLearningOutcomeCts(model.LearningOutcomeCts);
            ls.LearningOutcomeSubjectId = await learningOutcomeSubjectRepository.CreateLearningOutcomeSubject(model.LearningOutcomeSubjects);
            ls.Lsduration = TimeSpan.Zero;
            context.Ls.Add(ls);
            await context.SaveChangesAsync();
            await keywordRepository.CreateKeywords(model.Keywords, ls.Idls);
            await lsCorrelationRepository.CreateTeachingCorrelationSubjects(model.CorrelationSubjectIds, ls.Idls);
            logger.LogInformation($"Successfully created learning scenario with id { ls.Idls }");
            return ls.Idls;
        }

        /// <summary>
        /// Deletes scenario if it exists in database and if user that created the scenario
        /// is the same as the currently logged in user. Also deletes all lsLa objects which
        /// are connecting objects between a learning scenario and its activities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of deleted learning scenario</returns>
        public async Task<int> DeleteScenario(int id)
        {
            var ls = await context.Ls.FindAsync(id);
            if(ls == null)
            {
                throw new NotFoundException($"Scenario {id} does not exist.");
            }

            if(ls.UserId.ToString() != httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                throw new NotAuthorizedException($"You are not authorized to delete scenario {id}");
            }

            var lsLas = context.Lsla.Where(x => x.Lsid == id);
            foreach (var lsLa in lsLas)
            {
                context.Lsla.Remove(lsLa);
            }
            context.Remove(ls);
            await context.SaveChangesAsync();
            return id;
        }

        /// <summary>
        /// Retrieves scenario data with provided id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Learning scenario data transfer model</returns>
        public async Task<LsDTO> GetScenario(int id)
        {
            var ls = await context.Ls.FindAsync(id);
            if(ls == null)
            {
                logger.LogError($"Scenario with id { id } not found.");
                throw new NotFoundException($"Learning scenario with id {id} not found.");
            }
            if(ls.LstypeId == (int) LsTypeEnum.Private && ls.UserId != httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                logger.LogError($"Not authorized to update scenario { id }");
                throw new NotAuthorizedException($"You are not authorized to view this resource.");
            }

            var lsDTO = mapper.Map<LsDTO>(ls);

            // Add user
            lsDTO.UserId = ls.UserId;
            var keywords = context.Lskeyword.Where(x => x.Lsid == ls.Idls)
                .ToList();
            foreach (var keyword in keywords)
            {
                var kwrd = await context.Keyword.FindAsync(keyword.Keywordid);
                lsDTO.Keywords.Add(kwrd.KeywordName);
            }


             var correlations = context.LscorrelationInterdisciplinarity.Where(x => x.Lsid == ls.Idls)
                .Select(x => x.TeachingSubjectId)
                .ToList();
            foreach (var correlation in correlations)
            {
                var corr = await context.TeachingSubject.FindAsync(correlation);
                lsDTO.CorrelationInterdisciplinaritySubjects.Add(corr.TeachingSubjectName);
            }

            var taName = await context.TeachingSubject.FindAsync(ls.TeachingSubjectId);
            lsDTO.TeachingSubjectName = taName.TeachingSubjectName;

            // Add learningOutcomeCt
            var learningOutcomeCt = await context.LearningOutcomeCt.FindAsync(ls.LearningOutcomeCtid);
            var learningOutcomeCts = learningOutcomeCt.LearningOutcomeCtstatement.Trim().Split("||");
            learningOutcomeCts = learningOutcomeCts.Take(learningOutcomeCts.Count() - 1).ToArray();
            lsDTO.LearningOutcomeCts = learningOutcomeCts;

            //Add learningOutcomeSubject
            var learningOutcomeSubject = await context.LearningOutcomeSubject.FindAsync(ls.LearningOutcomeSubjectId);
            var learningOutcomeSubjects = learningOutcomeSubject.LearningOutcomeSubjectStatement.Trim().Split("||");
            learningOutcomeSubjects = learningOutcomeSubjects.Take(learningOutcomeSubjects.Count() - 1).ToArray();
            lsDTO.LearningOutcomeSubjects = learningOutcomeSubjects;
            lsDTO.Las = await activityService.GetActivities(id);
            lsDTO.Las = lsDTO.Las.OrderBy(x => x.OrdinalNumber).ToList();

            // Strategy method, Collaboration and Teaching Aids from LA
            foreach (var la in lsDTO.Las)
            {
                lsDTO.CollaborationNames.Add(la.Lacollaboration);
                lsDTO.CollaborationNames = lsDTO.CollaborationNames.Union(lsDTO.CollaborationNames).ToList();
                lsDTO.StrategyMethods = lsDTO.StrategyMethods.Union(la.StrategyMethods).ToList();
                var teachingAidTeacher = context.LateachingAid.Where(x => x.Laid == la.Idla && x.LateachingAidUser == false);
                foreach(var tat in teachingAidTeacher)
                {
                    lsDTO.TeachingAidTeacher = await context.TeachingAid.Where(x => x.IdteachingAid == tat.TeachingAidId).ToListAsync();
                }
                var teachingAidStudent = context.LateachingAid.Where(x => x.Laid == la.Idla && x.LateachingAidUser == true);
                foreach(var tas in teachingAidStudent)
                {
                    lsDTO.TeachingAidUser = await context.TeachingAid.Where(x => x.IdteachingAid == tas.TeachingAidId).ToListAsync();
                }
            }
            return lsDTO;
        }

        /// <summary>
        /// Retrieves all learning scenarios that a particular user created
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of learning scenario data transfer objects for a user</returns>
        public async Task<IEnumerable<LsDTO>> GetUserScenarios(string id)
        {
            var userLs = new List<Ls>();
            if (id != httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                userLs = await context.Ls.Where(x => x.UserId == id && x.LstypeId != (int) LsTypeEnum.Private && x.IsDeleted == false).ToListAsync();
            }
            else
            {
                userLs = await context.Ls.Where(x => x.UserId == id && x.IsDeleted == false).ToListAsync();
            }

            List<LsDTO> lsDTOs = new List<LsDTO>();
            foreach (var ls in userLs)
            {
                var lsDTO = mapper.Map<LsDTO>(ls);
                lsDTOs.Add(lsDTO);
            }
            return lsDTOs;
        }

        /// <summary>
        /// Retrieves a learning scenario by a provided id parameter and updates
        /// the scenario with data provided in a learning scenario binding model.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Id of updated scenario</returns>
        public async Task<int> UpdateScenario(int id, LsBM model)
        {
            var ls = await context.Ls.FindAsync(id);
            if(ls == null)
            {
                throw new NotFoundException($"Scenario {id} does not exist.");
            }

            if (ls.UserId.ToString() != httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                logger.LogError($"Not authorized to view scenario with id { id }");
                throw new NotAuthorizedException($"You are not authorized to view this resource.");
            }

            ls = mapper.Map<Ls>(model);
            ls.LearningOutcomeCtid = await learningOutcomeCtRepository.CreateLearningOutcomeCts(model.LearningOutcomeCts);
            ls.LearningOutcomeSubjectId = await learningOutcomeSubjectRepository.CreateLearningOutcomeSubject(model.LearningOutcomeSubjects);
            context.Ls.Update(ls);
            await context.SaveChangesAsync();
            await keywordRepository.RemoveKeywords(model.Keywords, ls.Idls);
            await keywordRepository.CreateKeywords(model.Keywords, ls.Idls);
            await lsCorrelationRepository.RemoveLsCorr(ls.Idls);
            await lsCorrelationRepository.CreateTeachingCorrelationSubjects(model.CorrelationSubjectIds, ls.Idls);
            return id;
        }

        public async Task<PagedList<LsListDTO>> GetScenarios(ScenarioParameters scenarioParameters)
        {
            var scenarios = context.Ls.Where(x => x.LstypeId != (int) LsTypeEnum.Private && x.IsDeleted == false).AsQueryable();
            IQueryable<Ls> searchResults = Enumerable.Empty<Ls>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(scenarioParameters.Keyword))
            {
                searchResults = SearchScenariosByKeyword(scenarioParameters);
            }
            if (!string.IsNullOrWhiteSpace(scenarioParameters.Lsname))
            {
                searchResults = SearchScenariosByName(ref scenarios, scenarioParameters);
            }

            if (searchResults.Count() == 0)
            {
                scenarios = FilterScenarios(ref scenarios, scenarioParameters);

                scenarios = sortService.ApplySort(scenarios, scenarioParameters.OrderBy);
                return await PagedList<LsListDTO>.ToPagedList(scenarios.Select(x => mapper.Map<LsListDTO>(x)),
                    scenarioParameters.PageNumber,
                    scenarioParameters.PageSize);
            }
            else
            {
                searchResults = FilterScenarios(ref searchResults, scenarioParameters);

                searchResults = sortService.ApplySort(searchResults, scenarioParameters.OrderBy);
                return await PagedList<LsListDTO>.ToPagedList(searchResults.Select(x => mapper.Map<LsListDTO>(x)),
                    scenarioParameters.PageNumber,
                    scenarioParameters.PageSize);
            }
        }

        public async Task<int> GetScenariosCount(ScenarioParameters scenarioParameters)
        {
            var scenarios = context.Ls.Where(x => x.LstypeId != (int)LsTypeEnum.Private).AsQueryable();
            IQueryable<Ls> searchResults = Enumerable.Empty<Ls>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(scenarioParameters.Keyword))
            {
                searchResults = SearchScenariosByKeyword(scenarioParameters);
            }
            if (!string.IsNullOrWhiteSpace(scenarioParameters.Lsname))
            {
                searchResults = SearchScenariosByName(ref scenarios, scenarioParameters);
            }

            if (searchResults.Count() == 0)
            {
                scenarios = FilterScenarios(ref scenarios, scenarioParameters);
                var result = await scenarios.ToListAsync();
                return result.Count();
            }
            else
            {
                searchResults = FilterScenarios(ref searchResults, scenarioParameters);
                var result = await searchResults.ToListAsync();
                return result.Count();
            }
        }

        private IQueryable<Ls> SearchScenariosByKeyword(ScenarioParameters scenarioParameters)
        {
            IQueryable<Ls> ls = Enumerable.Empty<Ls>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(scenarioParameters.Keyword.Trim()))
            {
                var keyword = keywordRepository.GetKeyword(scenarioParameters.Keyword);
                if (keyword != null)
                {
                    ls = context.Lskeyword.Where(x => x.Keywordid == keyword.Idkeyword)
                        .Select(x => x.Lsid)
                        .Select(x => context.Ls.Find(x))
                        .Select(x => x);
                    ls = ls.Where(x => x.LstypeId != (int)LsTypeEnum.Private && x.IsDeleted == false);
                }
            }
            return ls;
        }

        private IQueryable<Ls> SearchScenariosByName(ref IQueryable<Ls> scenarios, ScenarioParameters scenarioParameters)
        {
            if (!string.IsNullOrWhiteSpace(scenarioParameters.Lsname))
            {
                scenarios = scenarios.Where(x => x.Lsname.ToLower().Trim().Contains(scenarioParameters.Lsname.ToLower().Trim()) && x.IsDeleted == false);
            }
            return scenarios;
        }

        private IQueryable<Ls> FilterScenarios(ref IQueryable<Ls> scenarios, ScenarioParameters scenarioParameters)
        {
            if (scenarioParameters.Lsgrade >= 1 && scenarioParameters.Lsgrade <= 8)
            {
                scenarios = scenarios.Where(x => x.Lsgrade == scenarioParameters.Lsgrade && x.IsDeleted == false);
            }

            if(scenarioParameters.TeachingSubjectId != 0)
            {
                scenarios = scenarios.Where(x => x.TeachingSubjectId == scenarioParameters.TeachingSubjectId && x.IsDeleted == false);
            }

            return scenarios;
        }
    }
}
