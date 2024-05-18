using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldView;
    [SerializeField] private TMP_Text _daimondView;
    [SerializeField] private PlayerWallet _wallet;

    private void Awake()
    {
        _wallet.MoneyChanged += OnPlayerMoneyChenget;
    }

    public void Initialize(int countGold, int countDaimond)
    {
        _goldView.text = countGold.ToString();
        _daimondView.text = countDaimond.ToString();
    }

    private void OnPlayerMoneyChenget()
    {
        _goldView.text = _wallet.CurrentGold.ToString();
        _daimondView.text = _wallet.CurrentDaimond.ToString();
    }
}