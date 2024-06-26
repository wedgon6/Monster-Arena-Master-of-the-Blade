public class LocalizationServise : ILocalizationServise
{
    private const string English = "English";
    private const string Russian = "Russian";
    private const string Turkish = "Turkish";

    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";

    public void ChangeLanguage(string languageCode)
    {
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

        Lean.Localization.LeanLocalization.SetCurrentLanguageAll(language);
    }
}