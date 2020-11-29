using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumRepository.CORE.Data.Models.Scenario
{
    public class LsBM
    {
        public string Lsname { get; set; }
        public string Lsdescription { get; set; }
        public int LsTypeId { get; set; }
        public int TeachingSubjectId { get; set; }
        public int? Lsgrade { get; set; }
        public List<string> LearningOutcomeCts { get; set; }
        public List<string> LearningOutcomeSubjects { get; set; }
        public List<string> Keywords { get; set; }
        public List<int> CorrelationSubjectIds { get; set; }
    }
}
