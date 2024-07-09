public class RangeThrow : TrainingItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddRangeThrow();
        base.Buy(parametersPlayer);
    }
}