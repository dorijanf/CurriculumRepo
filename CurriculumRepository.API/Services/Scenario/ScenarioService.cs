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

namespace CurriculumRepository.API.Services.Scenario
{
    public class ScenarioService : IScenarioService
    {
        private readonly CurriculumDatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<ScenarioService> logger;
        private readonly IActivityService activityService;
        private readonly ILearningOutcomeCtRepository learningOutcomeCtRepository;
        private readonly ILearningOutcomeSubjectRepository learningOutcomeSubjectRepository;
        private readonly IKeywordRepository keywordRepository;
        private readonly ILsCorrelationInterdisciplinarityRepository lsCorrelationRepository;

        public ScenarioService(CurriculumDatabaseContext context,
                              IMapper mapper,
                              IHttpContextAccessor httpContextAccessor,
                              ILogger<ScenarioService> logger,
                              IActivityService activityService,
                              ILearningOutcomeCtRepository learningOutcomeCtRepository,
                              ILearningOutcomeSubjectRepository learningOutcomeSubjectRepository,
                              IKeywordRepository keywordRepository,
                              ILsCorrelationInterdisciplinarityRepository lsCorrelationRepository
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
        }

        public async Task<int> CreateLs(LsBM model)
        {
            var ls = mapper.Map<Ls>(model);
            ls.UserId = Int32.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            ls.LearningOutcomeCtid = await learningOutcomeCtRepository.CreateLearningOutcomeCts(model.LearningOutcomeCts);
            ls.LearningOutcomeSubjectId = await learningOutcomeSubjectRepository.CreateLearningOutcomeSubject(model.LearningOutcomeSubjects);
            await keywordRepository.CreateKeywords(model.Keywords, ls.Idls);
            await lsCorrelationRepository.CreateTeachingCorrelationSubjects(model.CorrelationSubjectIds, ls.Idls);
            context.Ls.Add(ls);
            logger.LogInformation($"Successfully created learning scenario with id { ls.Idls }");
            await context.SaveChangesAsync();
            return ls.Idls;
        }

        public async Task<LsDTO> GetLs(int id)
        {
            var ls = await context.Ls.FindAsync(id);
            if(ls == null)
            {
                logger.LogError($"Scenario with id { id } not found.");
                throw new NotFoundException($"Learning scenario with id {id} not found.");
            }
            if(ls.LstypeId == 1 && !(ls.UserId.ToString() == httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                logger.LogError($"Not authorized to view scenario with id { id }");
                throw new NotAuthorizedException($"You are not authorized to view this resource.");
            }
            var lsDTO = mapper.Map<LsDTO>(ls);
            lsDTO.Keywords = context.Lskeyword.Where(x => x.Lsid == ls.Idls)
                .Select(x => x.Keyword)
                .ToList();
            lsDTO.CorrelationInterdisciplinaritySubjects = context.LscorrelationInterdisciplinarity.Where(x => x.Lsid == ls.Idls)
                .Select(x => x.TeachingSubject)
                .ToList();
            lsDTO.Las = await activityService.GetActivities(id);
            var duration = 0;
            foreach (var la in lsDTO.Las)
            {
                duration += la.Laduration;
                lsDTO.StrategyMethods.Add((StrategyMethod)la.LastrategyMethod.Select(x => x));
                lsDTO.CollaborationNames.Add(la.Lacollaboration);
                lsDTO.TeachingAids.Add((TeachingAid)la.LateachingAids.Select(x => x));
            }
            lsDTO.Lsduration = duration;
            return lsDTO;
        }
    }
}
