using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class StrategyMethod
    {
        public StrategyMethod()
        {
            LastrategyMethod = new HashSet<LastrategyMethod>();
        }

        public int IdstrategyMethod { get; set; }
        public byte[] StrategyMethodPicture { get; set; }
        public string StrategyMethodName { get; set; }
        public int StrategyMethodTypeId { get; set; }
        public bool? Active { get; set; }

        public virtual StrategyMethodType StrategyMethodType { get; set; }
        public virtual ICollection<LastrategyMethod> LastrategyMethod { get; set; }
    }
}
