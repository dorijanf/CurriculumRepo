using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Helpers;

namespace CurriculumRepository.CORE.Entities
{
    public partial class LscorrelationInterdisciplinarity : IDeletable
    {
        public int IdlscorrelationInterdisciplinarity { get; set; }
        public int Lsid { get; set; }
        public int TeachingSubjectId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Ls Ls { get; set; }
        public virtual TeachingSubject TeachingSubject { get; set; }
    }
}
