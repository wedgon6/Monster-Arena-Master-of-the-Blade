using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerWallet _wallet = new PlayerWallet();

    public void InitializePlayer(int gold, int daimond)
    {
        _wallet.Initialize(gold, daimond);
    }
}