﻿using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class Ls
    {
        public Ls()
        {
            LscorrelationInterdisciplinarity = new HashSet<LscorrelationInterdisciplinarity>();
            Lskeyword = new HashSet<Lskeyword>();
            Lsla = new HashSet<Lsla>();
        }

        public int Idls { get; set; }
        public string Lsname { get; set; }
        public string Lsdescription { get; set; }
        public byte Lsduration { get; set; }
        public string Lsacknowledgment { get; set; }
        public int UserId { get; set; }
        public int TeachingSubjectId { get; set; }
        public int LstypeId { get; set; }
        public int LearningOutcomeSubjectId { get; set; }
        public int LearningOutcomeCtid { get; set; }
        public int? Lsgrade { get; set; }

        public virtual LearningOutcomeCt LearningOutcomeCt { get; set; }
        public virtual LearningOutcomeSubject LearningOutcomeSubject { get; set; }
        public virtual Lstype Lstype { get; set; }
        public virtual TeachingSubject TeachingSubject { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<LscorrelationInterdisciplinarity> LscorrelationInterdisciplinarity { get; set; }
        public virtual ICollection<Lskeyword> Lskeyword { get; set; }
        public virtual ICollection<Lsla> Lsla { get; set; }
    }
}
