using Agava.YandexGames;
using System.Collections;
using UnityEngine;

public class SDKInitialize : MonoBehaviour
{
    [SerializeField] private LoadingPlayScene _loadindScene;
    [SerializeField] private LocalizationRoot _localization;

#if UNITY_EDITOR
    private void Start()
    {
        //_localization.Init();
        Services.Init();
        Services.LocalizationService.ChangeLanguage();
        _loadindScene.StartLoadScene();
    }
#else
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
            Services.Init();
            _loadindScene.StartLoadScene();
        }
    }

    private void OnSuccessColback()
    {
        Services.Init();
        _loadindScene.StartLoadScene();
    }

    private void OnErrorColbak(string error)
    {
        Services.Init();
        _loadindScene.StartLoadScene();
    }
#endif
}