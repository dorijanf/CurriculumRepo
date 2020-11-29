using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Helpers;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class LearningOutcomeSubject : IDeletable
    {
        public LearningOutcomeSubject()
        {
            Ls = new HashSet<Ls>();
        }

        public int IdlearningOutcomeSubject { get; set; }
        public string LearningOutcomeSubjectStatement { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
    }
}
