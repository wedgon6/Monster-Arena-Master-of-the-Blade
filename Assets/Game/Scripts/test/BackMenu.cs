using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMenu : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _button.onClick.AddListener(BackMenuScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(BackMenuScene);
    }

    private void BackMenuScene()
    {
        RelocateEarnedMoney();
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MenuScene");
    }

    private void RelocateEarnedMoney()
    {
        Services.SaveService.RelocateData(_player.PlayerWallet);
    }
}