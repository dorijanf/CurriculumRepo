using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class Lsla
    {
        public int Idlsla { get; set; }
        public int Lsid { get; set; }
        public int Laid { get; set; }
        public int Rank { get; set; }

        public virtual La La { get; set; }
        public virtual Ls Ls { get; set; }
    }
}
