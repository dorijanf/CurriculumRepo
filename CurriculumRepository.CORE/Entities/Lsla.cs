using CurriculumRepository.API.Models.Entities;

namespace CurriculumRepository.CORE.Entities
{
    public partial class Lsla
    {
        public int Idlsla { get; set; }
        public int Lsid { get; set; }
        public int Laid { get; set; }
        public int Rank { get; set; }

        public virtual La La { get; set; }
        public virtual Ls Ls { get; set; }
    }
}
