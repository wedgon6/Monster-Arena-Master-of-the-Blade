public interface ISaveService
{
    public int RelocateGold { get; set; }
    public int RelocateDaimond { get; set; }

    public bool TryGetData(out GameInfo data);
    public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parametersPlayer, TrainingShop abillityShop, Worckshop skeenShop);
    public void RelocateData(PlayerWallet playerWallet, int countStars, int earnedScore);
    public void RemoveData();
}