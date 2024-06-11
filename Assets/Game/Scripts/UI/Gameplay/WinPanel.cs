using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private Button _backMenuButton;
    [SerializeField] private Button _doubleRevardButton;
    [SerializeField] private TMP_Text _goldCount;
    [SerializeField] private TMP_Text _daimondCount;

    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
        _goldCount.text = _player.PlayerWallet.CurrentGold.ToString();
        _daimondCount.text = _player.PlayerWallet.CurrentDaimond.ToString();

    }

    private void OnEnable()
    {
        _backMenuButton.onClick.AddListener(BackMenuScene);
    }

    private void OnDisable()
    {
        _backMenuButton.onClick.RemoveListener(BackMenuScene);
    }

    private void BackMenuScene()
    {
        RelocateEarnedMoney();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("1_MenuScene");
    }

    private void RelocateEarnedMoney()
    {
        Services.SaveService.RelocateData(_player.PlayerWallet, 1);
    }
}