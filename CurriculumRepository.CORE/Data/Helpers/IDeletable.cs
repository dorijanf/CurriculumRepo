using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumRepository.CORE.Data.Helpers
{
    interface IDeletable
    {
        public bool IsDeleted { get; set; }
    }
}
