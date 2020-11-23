using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class LscorrelationInterdisciplinarity
    {
        public int IdlscorrelationInterdisciplinarity { get; set; }
        public int Lsid { get; set; }
        public int TeachingSubjectId { get; set; }

        public virtual Ls Ls { get; set; }
        public virtual TeachingSubject TeachingSubject { get; set; }
    }
}
