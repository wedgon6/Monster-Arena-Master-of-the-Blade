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
    
    protected Player _player;

    public virtual void Initialize(Player player)
    {
        _player = player;
        _goldCount.text = _player.PlayerWallet.CurrentGold.ToString();
        _daimondCount.text = _player.PlayerWallet.CurrentDaimond.ToString();
    }

    protected virtual void RelocateEarnedData() { }
    protected virtual void OnAdsButtonClick() { }

    private void OnEnable()
    {
        if(_adsActionButton != null)
            _adsActionButton.onClick.AddListener(OnAdsButtonClick);

        _backMenuButton.onClick.AddListener(BackMenuScene);
    }

    private void OnDisable()
    {
        if (_adsActionButton != null)
            _adsActionButton.onClick.RemoveListener(OnAdsButtonClick);
        
        _backMenuButton.onClick.RemoveListener(BackMenuScene);
    }

    private void BackMenuScene()
    {
        RelocateEarnedData();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("1_MenuScene");
    }
}