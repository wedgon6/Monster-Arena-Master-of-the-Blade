public class MoveSpeed : TrainingItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddMoveSpeed();
        base.Buy(parametersPlayer);
    }
}