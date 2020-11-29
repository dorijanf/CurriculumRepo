using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Helpers;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class LearningOutcomeCt : IDeletable
    {
        public LearningOutcomeCt()
        {
            Ls = new HashSet<Ls>();
        }

        public int IdlearningOutcomeCt { get; set; }
        public string LearningOutcomeCtstatement { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
    }
}
