using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumRepository.CORE.Data.Models.Scenario
{
    public class LsListDTO
    {
        public int Idls { get; set; }
        public string Lsname { get; set; }
        public string Lsdescription { get; set; }
        public int UserId { get; set; }
        public int TeachingSubjectId { get; set; }
        public int? Lsgrade { get; set; }
    }
}
