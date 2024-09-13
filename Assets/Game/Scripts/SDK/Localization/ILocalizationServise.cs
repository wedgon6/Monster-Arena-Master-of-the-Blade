using Lean.Localization;

public interface ILocalizationServise 
{
    public void ChangeLanguage(string language, LeanLocalization leanLocalization);
}