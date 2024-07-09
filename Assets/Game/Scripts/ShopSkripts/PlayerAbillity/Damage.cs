public class Damage : TrainingItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddDamage();
        base.Buy(parametersPlayer);
    }
}