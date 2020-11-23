using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class LearningOutcomeCt
    {
        public LearningOutcomeCt()
        {
            Ls = new HashSet<Ls>();
        }

        public int IdlearningOutcomeCt { get; set; }
        public string LearningOutcomeCtstatement { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
    }
}
