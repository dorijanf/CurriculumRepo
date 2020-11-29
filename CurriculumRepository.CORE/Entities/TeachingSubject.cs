using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Helpers;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class TeachingSubject : IDeletable
    {
        public TeachingSubject()
        {
            Ls = new HashSet<Ls>();
            LscorrelationInterdisciplinarity = new HashSet<LscorrelationInterdisciplinarity>();
        }

        public int IdteachingSubject { get; set; }
        public string TeachingSubjectName { get; set; }
        public bool? Active { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
        public virtual ICollection<LscorrelationInterdisciplinarity> LscorrelationInterdisciplinarity { get; set; }
    }
}
