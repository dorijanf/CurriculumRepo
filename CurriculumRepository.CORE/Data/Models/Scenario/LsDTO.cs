using CurriculumRepository.CORE.Data.Models.Activity;
using CurriculumRepository.CORE.Entities;
using System;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Data.Models.Scenario
{
    public class LsDTO
    {
        public LsDTO()
        {
            Keywords = new List<string>();
            CorrelationInterdisciplinaritySubjects = new List<string>();
            CollaborationNames = new List<string>();
            TeachingAidUser = new List<TeachingAid>();
            TeachingAidTeacher = new List<TeachingAid>();
            StrategyMethods = new List<StrategyMethodBM>();
            Las = new List<LaDTO>();
        }

        public int Idls { get; set; }
        public string UserId { get; set; }
        public string Lsname { get; set; }
        public string Lsdescription { get; set; }
        public string LstypeName { get; set; }
        public string TeachingSubjectName { get; set; }
        public int? Lsgrade { get; set; }
        public string[] LearningOutcomeSubjects { get; set; }
        public string[] LearningOutcomeCts { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> CorrelationInterdisciplinaritySubjects { get; set; }
        public TimeSpan Lsduration { get; set; }
        public List<StrategyMethodBM> StrategyMethods { get; set; }
        public List<string> CollaborationNames { get; set; }
        public List<TeachingAid> TeachingAidUser{ get; set; }
        public List<TeachingAid> TeachingAidTeacher { get; set; }
        public List<LaDTO> Las { get; set; }
    }
}
