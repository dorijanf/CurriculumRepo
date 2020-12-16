using CurriculumRepository.CORE.Entities;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Data.Models.Activity
{
    public class LaBM
    {
        public LaBM()
        {
            StrategyMethods = new List<StrategyMethodBM>();
            LaTeachingAidUser = new List<TeachingAid>();
            LaTeachingAidTeacher = new List<TeachingAid>();
        }
        public int OrdinalNumber { get; set; }
        public int? PerformanceId { get; set; }
        public int LatypeId { get; set; }
        public bool DigitalTechnology { get; set; }
        public string Laname { get; set; }
        public int LadurationMinute { get; set; }
        public string Ladescription { get; set; }
        public List<StrategyMethodBM> StrategyMethods { get; set; }
        public int CooperationId { get; set; }
        public List<TeachingAid> LaTeachingAidUser { get; set; }
        public List<TeachingAid> LaTeachingAidTeacher { get; set; }
    }
}
