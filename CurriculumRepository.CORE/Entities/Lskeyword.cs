using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Helpers;

namespace CurriculumRepository.CORE.Entities
{
    public partial class Lskeyword : IDeletable
    {
        public int Idlskeyword { get; set; }
        public int Lsid { get; set; }
        public int Keywordid { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Keyword Keyword { get; set; }
        public virtual Ls Ls { get; set; }
    }
}
