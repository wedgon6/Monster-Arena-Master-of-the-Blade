public class Damage : ShopItem
{
    public override void Buy(ParametersPlayer parametersPlayer)
    {
        parametersPlayer.AddDamage();
        base.Buy(parametersPlayer);
    }
}