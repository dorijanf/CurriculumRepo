namespace CurriculumRepository.CORE.Entities
{
    public partial class LastrategyMethod
    {
        public int IdlastrategyMethod { get; set; }
        public int Laid { get; set; }
        public int StrategyMethodId { get; set; }

        public virtual La La { get; set; }
        public virtual StrategyMethod StrategyMethod { get; set; }
    }
}
