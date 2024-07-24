using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Button _backMenuButton;
    [SerializeField] private Button _reviveButton;
    [SerializeField] private TMP_Text _goldCount;
    [SerializeField] private TMP_Text _daimondCount;

    private Player _player;

    public event Action ShowRevardAd;

    public void Initialize(Player player)
    {
        _player = player;
        _goldCount.text = _player.PlayerWallet.CurrentGold.ToString();
        _daimondCount.text = _player.PlayerWallet.CurrentDaimond.ToString();
    }

    private void OnEnable()
    {
        _reviveButton.onClick.AddListener(RevivePlayerButton);
        _backMenuButton.onClick.AddListener(BackMenuScene);
    }

    private void OnDisable()
    {
        _reviveButton.onClick.RemoveListener(RevivePlayerButton);
        _backMenuButton.onClick.RemoveListener(BackMenuScene);
    }

    private void RevivePlayerButton()
    {
        Services.AdvertisemintService.ShowResurrectAd(_player);
        ShowRevardAd?.Invoke();
        _reviveButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void BackMenuScene()
    {
        RelocateEarnedMoney();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("1_MenuScene");
    }

    private void RelocateEarnedMoney()
    {
        Services.SaveService.RelocateData(_player.PlayerWallet, 0, _player.EarnedScore);
    }
}