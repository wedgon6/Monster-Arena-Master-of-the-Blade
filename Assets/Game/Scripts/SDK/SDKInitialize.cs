using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class SDKInitialize : MonoBehaviour
{
    [SerializeField] private LoadindPlayScene _loadindScene;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialized);
    }

    private void OnInitialized()
    {
        if (PlayerAccount.IsAuthorized)
        {
            Agava.YandexGames.Utility.PlayerPrefs.Load(OnSuccessColback, OnErrorColbak);
        }
        else
        {
            _loadindScene.StartLoadScene();
        }
    }

    private void OnSuccessColback() => _loadindScene.StartLoadScene();

    private void OnErrorColbak(string error) => _loadindScene.StartLoadScene();
}