using Agava.YandexGames;
using MonsterArenaMasterOfTheBlade.ServicesScripts;
using System.Collections;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.SDK
{
    public class SDKInitialize : MonoBehaviour
    {
        [SerializeField] private LoadingPlayScene _loadindScene;

#if UNITY_EDITOR
        private void Start()
        {
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
            Services.LocalizationService.ChangeLanguage();
            _loadindScene.StartLoadScene();
        }
    }

    private void OnSuccessColback()
    {
        Services.Init();
        Services.LocalizationService.ChangeLanguage();
        _loadindScene.StartLoadScene();
    }

    private void OnErrorColbak(string error)
    {
        Services.Init();
        Services.LocalizationService.ChangeLanguage();
        _loadindScene.StartLoadScene();
    }
#endif
    }
}