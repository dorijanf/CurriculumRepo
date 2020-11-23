using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class Latype
    {
        public Latype()
        {
            La = new HashSet<La>();
        }

        public int Idlatype { get; set; }
        public string LatypeName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<La> La { get; set; }
    }
}
