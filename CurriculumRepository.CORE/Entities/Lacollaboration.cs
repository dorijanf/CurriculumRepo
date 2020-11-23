using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class Lacollaboration
    {
        public Lacollaboration()
        {
            La = new HashSet<La>();
        }

        public int Idcollaboration { get; set; }
        public string CollaborationName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<La> La { get; set; }
    }
}
