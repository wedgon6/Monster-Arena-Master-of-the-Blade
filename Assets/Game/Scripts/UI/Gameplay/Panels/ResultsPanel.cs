using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsPanel : MonoBehaviour
{
    [SerializeField] private Button _backMenuButton;
    [SerializeField] protected Button _adsActionButton;
    [SerializeField] protected TMP_Text _goldCount;
    [SerializeField] protected TMP_Text _daimondCount;

    private PlayerWallet _playerWallet;
    protected Player _player;

    public virtual void Initialize(Player player)
    {
        _player = player;
        _playerWallet = _player.PlayerWallet;
        _playerWallet.MoneyChanged += OnPlayerMoneyChenged;
        _goldCount.text = _playerWallet.CurrentGold.ToString();
        _daimondCount.text = _playerWallet.CurrentDaimond.ToString();
    }

    protected virtual void RelocateEarnedData() { }
    protected virtual void OnAdsButtonClick() { }

    private void OnEnable()
    {
        if (_adsActionButton != null)
            _adsActionButton.onClick.AddListener(OnAdsButtonClick);

        _backMenuButton.onClick.AddListener(BackMenuScene);
    }

    private void OnDisable()
    {
        if (_adsActionButton != null)
            _adsActionButton.onClick.RemoveListener(OnAdsButtonClick);
        
        _backMenuButton.onClick.RemoveListener(BackMenuScene);
        _playerWallet.MoneyChanged -= OnPlayerMoneyChenged;
    }

    private void BackMenuScene()
    {
        RelocateEarnedData();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("1_MenuScene");
    }

    private void OnPlayerMoneyChenged()
    {
        _goldCount.text = _playerWallet.CurrentGold.ToString();
        _daimondCount.text = _playerWallet.CurrentDaimond.ToString();
    }
}