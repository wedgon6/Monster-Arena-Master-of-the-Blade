public interface ISaveService
{
    public bool TryGetData(out GameInfo data);
    public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parametersPlayer, Shop shop);
    public void RelocateData(PlayerWallet playerWallet, int countStars, int earnedScore);
}