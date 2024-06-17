public interface ISaveService
{
    public bool TryGetData(out GameInfo data);
    public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap, ParametersPlayer parametersPlayer);
    public void RelocateData(PlayerWallet playerWallet, int countStars);
}