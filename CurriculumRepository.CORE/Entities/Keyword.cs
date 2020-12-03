using CurriculumRepository.CORE.Data.Helpers;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class Keyword
    {
        public Keyword()
        {
            Lskeyword = new HashSet<Lskeyword>();
        }

        public int Idkeyword { get; set; }
        public string KeywordName { get; set; }
        public virtual ICollection<Lskeyword> Lskeyword { get; set; }
    }
}
