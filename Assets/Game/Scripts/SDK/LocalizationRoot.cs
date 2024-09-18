using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class LocalizationRoot : MonoBehaviour
{
    private const string English = "English";
    private const string Russian = "Russian";
    private const string Turkish = "Turkish";

    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";

    //private void Awake()
    //{
    //    ChangeLanguage();
    //}

    public void Init()
    {
       ChangeLanguage();
    }

    private void ChangeLanguage()
    {
#if UNITY_EDITOR
        string languageCode = "tr";
#else
        string languageCode = YandexGamesSdk.Environment.i18n.lang;
#endif
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

        LeanLocalization.SetCurrentLanguageAll(language);
    }
}