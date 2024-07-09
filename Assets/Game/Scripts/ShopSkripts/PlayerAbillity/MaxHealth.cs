public class MaxHealth : TrainingItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddMaxHealth();
        base.Buy(parametersPlayer);
    }
}