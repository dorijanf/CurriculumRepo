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
            Keywords = new List<Keyword>();
            CorrelationInterdisciplinaritySubjects = new List<TeachingSubject>();
            CollaborationNames = new List<Lacollaboration>();
            TeachingAids = new List<TeachingAid>();
            Las = new List<LaDTO>();
        }

        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Lsname { get; set; }
        public string Lsdescription { get; set; }
        public string LstypeName { get; set; }
        public string TeachingSubjectName { get; set; }
        public int? Lsgrade { get; set; }
        public string LearningOutcomeSubjects { get; set; }
        public string LearningOutcomeCts { get; set; }
        public List<Keyword> Keywords { get; set; }
        public List<TeachingSubject> CorrelationInterdisciplinaritySubjects { get; set; }
        public TimeSpan Lsduration { get; set; }
        public List<StrategyMethod> StrategyMethods { get; set; }
        public List<Lacollaboration> CollaborationNames { get; set; }
        public List<TeachingAid> TeachingAids { get; set; }
        public List<LaDTO> Las { get; set; }
    }
}
