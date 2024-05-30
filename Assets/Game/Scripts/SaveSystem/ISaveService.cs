public interface ISaveService
{
    public bool TryGetData(out GameInfo data);
    public void SaveData(PlayerWallet playerWallet, ChoiceMap choiceMap);
    public void RelocateData(PlayerWallet playerWallet);
}