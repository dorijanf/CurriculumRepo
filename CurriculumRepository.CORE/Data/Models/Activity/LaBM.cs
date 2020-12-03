using System;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Data.Models.Activity
{
    public class LaBM
    {
        public int OrdinalNumber { get; set; }
        public int? PerformanceId { get; set; }
        public int LatypeId { get; set; }
        public bool DigitalTechnology { get; set; }
        public string Laname { get; set; }
        public TimeSpan Laduration { get; set; }
        public string Ladescription { get; set; }
        public List<StrategyMethodBM> StrategyMethods { get; set; }
        public int CooperationId { get; set; }
        public List<TeachingAidBM> LaTeachingAidUser { get; set; }
        public List<TeachingAidBM> LaTeachingAidTeacher { get; set; }
    }
}
