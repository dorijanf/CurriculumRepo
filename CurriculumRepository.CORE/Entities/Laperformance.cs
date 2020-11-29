using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
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
