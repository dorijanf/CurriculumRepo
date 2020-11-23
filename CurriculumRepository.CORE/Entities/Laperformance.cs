using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class Laperformance
    {
        public Laperformance()
        {
            La = new HashSet<La>();
        }

        public int Idperformance { get; set; }
        public string PerformanceName { get; set; }

        public virtual ICollection<La> La { get; set; }
    }
}
