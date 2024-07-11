public interface ISaveService
{
    public bool TryGetData(out GameInfo data);
    public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parametersPlayer, TrainingShop abillityShop, Worckshop skeenShop);
    public void RelocateData(PlayerWallet playerWallet, int countStars, int earnedScore);
}