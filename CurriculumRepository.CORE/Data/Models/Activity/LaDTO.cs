using CurriculumRepository.CORE.Entities;
using System;
using System.Collections.Generic;


namespace CurriculumRepository.CORE.Data.Models.Activity
{
    public class LaDTO
    {
        public int Idla { get; set; }
        public int OrdinalNumber { get; set; }
        public string Laperformance { get; set; }
        public string Latype { get; set; }
        public bool DigitalTechnology { get; set; }
        public string Laname { get; set; }
        public TimeSpan Laduration { get; set; }
        public string Ladescription { get; set; }
        public List<StrategyMethodBM> StrategyMethods { get; set; }
        public string Lacollaboration { get; set; }
        public byte Lagrade { get; set; }
        public List<TeachingAidBM> TeachingAids { get; set; }
        public string Laacknowledgment { get; set; }
    }
}
