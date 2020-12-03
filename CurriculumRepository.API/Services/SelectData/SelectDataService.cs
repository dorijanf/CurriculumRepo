using CurriculumRepository.API.Repositories.KeywordRepository;
using CurriculumRepository.API.Repositories.LaCollaborationRepository;
using CurriculumRepository.API.Repositories.LaPerformanceRepository;
using CurriculumRepository.API.Repositories.LaTypeRepository;
using CurriculumRepository.API.Repositories.StrategyMethodRepository;
using CurriculumRepository.API.Repositories.StrategyMethodTypeRepository;
using CurriculumRepository.API.Repositories.TeachingAidRepository;
using CurriculumRepository.API.Repositories.TeachingAidTypeRepository;
using CurriculumRepository.API.Repositories.TeachingSubjectRepository;
using CurriculumRepository.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumRepository.API.Services.SelectData
{
    public class SelectDataService : ISelectDataService
    {
        private readonly ITeachingSubjectRepository teachingSubjectRepository;
        private readonly ITeachingAidRepository teachingAidRepository;
        private readonly IStrategyMethodRepository strategyMethodRepository;
        private readonly IStrategyMethodTypeRepository strategyMethodTypeRepository;
        private readonly IKeywordRepository keywordRepository;
        private readonly ILaCollaborationRepository laCollaborationRepository;
        private readonly ILaPerformanceRepository laPerformanceRepository;
        private readonly ILaTypeRepository laTypeRepository;
        private readonly ITeachingAidTypeRepository teachingAidTypeRepository;

        public SelectDataService(ITeachingSubjectRepository teachingSubjectRepository,
                                ITeachingAidRepository teachingAidRepository,
                                IStrategyMethodRepository strategyMethodRepository,
                                IStrategyMethodTypeRepository strategyMethodTypeRepository,
                                IKeywordRepository keywordRepository,
                                ILaCollaborationRepository laCollaborationRepository,
                                ILaPerformanceRepository laPerformanceRepository,
                                ILaTypeRepository laTypeRepository,
                                ITeachingAidTypeRepository teachingAidTypeRepository)
        {
            this.teachingSubjectRepository = teachingSubjectRepository;
            this.teachingAidRepository = teachingAidRepository;
            this.strategyMethodRepository = strategyMethodRepository;
            this.strategyMethodTypeRepository = strategyMethodTypeRepository;
            this.keywordRepository = keywordRepository;
            this.laCollaborationRepository = laCollaborationRepository;
            this.laPerformanceRepository = laPerformanceRepository;
            this.laTypeRepository = laTypeRepository;
            this.teachingAidTypeRepository = teachingAidTypeRepository;
        }

        public async Task<IEnumerable<Keyword>> GetDropdownKeyword()
        {
            return await keywordRepository.GetAllKeywords();
        }

        public async Task<IEnumerable<Lacollaboration>> GetDropdownLaCollaboration()
        {
            return await laCollaborationRepository.GetLacollaborations();
        }

        public async Task<IEnumerable<Laperformance>> GetDropdownLaPerformance()
        {
            return await laPerformanceRepository.GetLaperformances();
        }

        public async Task<IEnumerable<Latype>> GetDropdownLaType()
        {
            return await laTypeRepository.GetLatypes();
        }

        public async Task<IEnumerable<StrategyMethod>> GetDropdownStrategyMethod()
        {
            return await strategyMethodRepository.GetStrategyMethods();
        }

        public async Task<IEnumerable<StrategyMethodType>> GetDropdownStrategyMethodType()
        {
            return await strategyMethodTypeRepository.GetStrategyMethodTypes();
        }

        public async Task<IEnumerable<TeachingAid>> GetDropdownTeachingAid()
        {
            return await teachingAidRepository.GetTeachingAids();
        }

        public async Task<IEnumerable<TeachingAidType>> GetDropdownTeachingAidType()
        {
            return await teachingAidTypeRepository.GetTeachingAidTypes();
        }

        public async Task<IEnumerable<TeachingSubject>> GetDropdownTeachingSubject()
        {
            return await teachingSubjectRepository.GetTeachingSubjects();
        }
    }
}
