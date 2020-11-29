using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class StrategyMethodType
    {
        public StrategyMethodType()
        {
            StrategyMethod = new HashSet<StrategyMethod>();
        }

        public int IdstrategyMethodType { get; set; }
        public string StrategyMethodTypeName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<StrategyMethod> StrategyMethod { get; set; }
    }
}
