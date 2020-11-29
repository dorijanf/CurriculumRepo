using CurriculumRepository.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumRepository.CORE.Data.Models.Activity
{
    public class LaDTO
    {
        public int Idla { get; set; }
        public int OrdinalNumber { get; set; }
        public Laperformance Laperformance { get; set; }
        public Latype Latype { get; set; }
        public bool DigitalTechnology { get; set; }
        public string Laname { get; set; }
        public int Laduration { get; set; }
        public string Ladescription { get; set; }
        public List<StrategyMethod> LastrategyMethod { get; set; }
        public Lacollaboration Lacollaboration { get; set; }
        public byte Lagrade { get; set; }
        public List<LateachingAid> LateachingAids { get; set; }
        public string Laacknowledgment { get; set; }
    }
}
