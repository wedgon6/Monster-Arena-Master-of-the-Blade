public class MoveSpeed : ShopItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddMoveSpeed();
        base.Buy(parametersPlayer);
    }
}