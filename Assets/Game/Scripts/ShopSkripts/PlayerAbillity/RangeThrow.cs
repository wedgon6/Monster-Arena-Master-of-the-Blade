public class RangeThrow : ShopItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddRangeThrow();
        base.Buy(parametersPlayer);
    }
}