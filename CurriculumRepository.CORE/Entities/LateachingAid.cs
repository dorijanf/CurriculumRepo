﻿namespace CurriculumRepository.CORE.Entities
{
    public partial class LateachingAid
    {
        public int IdlateachingAid { get; set; }
        public bool? LateachingAidUser { get; set; }
        public int Laid { get; set; }
        public int TeachingAidId { get; set; }

        public virtual La La { get; set; }
        public virtual TeachingAid TeachingAid { get; set; }
    }
}
