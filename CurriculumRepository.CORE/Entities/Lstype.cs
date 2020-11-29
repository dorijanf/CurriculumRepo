using CurriculumRepository.API.Models.Entities;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class Lstype
    {
        public Lstype()
        {
            Ls = new HashSet<Ls>();
        }

        public int Idlstype { get; set; }
        public string LstypeName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
    }
}
