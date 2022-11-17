namespace Source.Unit.Config.Interfaces
{
    public interface IUnitBoostableConfig
    {
        public float BoostForwardMultiplier { get; }
        public float BoostTurnMultiplier { get; }
        public float AccelerationTime { get; }
    }
}