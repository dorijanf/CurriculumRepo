using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class TeachingAid
    {
        public TeachingAid()
        {
            LateachingAid = new HashSet<LateachingAid>();
        }

        public int IdteachingAid { get; set; }
        public byte[] TeachingAidPicture { get; set; }
        public string TeachingAidName { get; set; }
        public int TeachingAidTypeId { get; set; }
        public bool? Active { get; set; }

        public virtual TeachingAidType TeachingAidType { get; set; }
        public virtual ICollection<LateachingAid> LateachingAid { get; set; }
    }
}
