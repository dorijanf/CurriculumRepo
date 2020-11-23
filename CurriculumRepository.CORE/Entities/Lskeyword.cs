using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class Lskeyword
    {
        public int Idlskeyword { get; set; }
        public int Lsid { get; set; }
        public int Keywordid { get; set; }

        public virtual Keyword Keyword { get; set; }
        public virtual Ls Ls { get; set; }
    }
}
