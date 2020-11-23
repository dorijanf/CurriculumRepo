using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class TeachingSubject
    {
        public TeachingSubject()
        {
            Ls = new HashSet<Ls>();
            LscorrelationInterdisciplinarity = new HashSet<LscorrelationInterdisciplinarity>();
        }

        public int IdteachingSubject { get; set; }
        public string TeachingSubjectName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
        public virtual ICollection<LscorrelationInterdisciplinarity> LscorrelationInterdisciplinarity { get; set; }
    }
}
