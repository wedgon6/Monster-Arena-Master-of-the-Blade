using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;

    private Gold _gold = new Gold(0);
    private Daimond _daimond = new Daimond(0);

    public PlayerWallet PlayerWallet => _wallet;

    private void Awake()
    {
        _wallet.Initialize(_gold.Value, _daimond.Value);
    }
}