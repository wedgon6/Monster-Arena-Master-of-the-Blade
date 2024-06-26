using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private const string English = "English";
    private const string Russian = "Russian";
    private const string Turkish = "Turkish";

    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";

    [SerializeField] private LeanLocalization _leanLocalization;

    private void Awake()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
       ChangeLanguage();
#endif
    }

    private void ChangeLanguage()
    {
        string languageCode = YandexGamesSdk.Environment.i18n.lang;
        string language = null;

        switch (languageCode)
        {
            case EnglishCode:
                language = English;
                break;
            case RussianCode:
                language = Russian;
                break;
            case TurkishCode:
                language = Turkish;
                break;
        }

        _leanLocalization.SetCurrentLanguage(language);
    }
}