using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class TeachingAidType
    {
        public TeachingAidType()
        {
            TeachingAid = new HashSet<TeachingAid>();
        }

        public int IdteachingAidType { get; set; }
        public string TeachingAidTypeName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<TeachingAid> TeachingAid { get; set; }
    }
}
