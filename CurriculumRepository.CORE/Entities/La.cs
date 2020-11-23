using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class La
    {
        public La()
        {
            LastrategyMethod = new HashSet<LastrategyMethod>();
            LateachingAid = new HashSet<LateachingAid>();
            Lsla = new HashSet<Lsla>();
        }

        public int Idla { get; set; }
        public string Laname { get; set; }
        public TimeSpan Laduration { get; set; }
        public string Ladescription { get; set; }
        public byte Lagrade { get; set; }
        public bool DigitalTechnology { get; set; }
        public string Laacknowledgment { get; set; }
        public int Lsid { get; set; }
        public int LatypeId { get; set; }
        public int? PerformanceId { get; set; }
        public int CooperationId { get; set; }
        public int LastrategiesId { get; set; }
        public int OrdinalNumber { get; set; }

        public virtual Lacollaboration Cooperation { get; set; }
        public virtual Latype Latype { get; set; }
        public virtual Laperformance Performance { get; set; }
        public virtual ICollection<LastrategyMethod> LastrategyMethod { get; set; }
        public virtual ICollection<LateachingAid> LateachingAid { get; set; }
        public virtual ICollection<Lsla> Lsla { get; set; }
    }
}
