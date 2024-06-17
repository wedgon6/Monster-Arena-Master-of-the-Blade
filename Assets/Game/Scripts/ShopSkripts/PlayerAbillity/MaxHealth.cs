public class MaxHealth : ShopItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddMaxHealth();
        base.Buy(parametersPlayer);
    }
}