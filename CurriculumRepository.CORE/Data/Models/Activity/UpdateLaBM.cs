﻿using CurriculumRepository.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumRepository.CORE.Data.Models.Activity
{
    public class UpdateLaBM
    {
        public int OrdinalNumber { get; set; }
        public int? PerformanceId { get; set; }
        public int LatypeId { get; set; }
        public bool DigitalTechnology { get; set; }
        public TimeSpan Laduration { get; set; }
        public string Ladescription { get; set; }
        public List<StrategyMethodBM> StrategyMethods { get; set; }
        public int CooperationId { get; set; }
        public List<TeachingAid> LaTeachingAidUser { get; set; }
        public List<TeachingAid> LaTeachingAidTeacher { get; set; }
    }
}
