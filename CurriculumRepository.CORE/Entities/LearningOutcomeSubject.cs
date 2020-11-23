using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class LearningOutcomeSubject
    {
        public LearningOutcomeSubject()
        {
            Ls = new HashSet<Ls>();
        }

        public int IdlearningOutcomeSubject { get; set; }
        public string LearningOutcomeSubjectStatement { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
    }
}
