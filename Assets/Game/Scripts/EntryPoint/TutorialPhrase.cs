using Lean.Localization;
using TMPro;
using UnityEngine;

public class TutorialPhrase : MonoBehaviour
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private TMP_Text _phease;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

    public TMP_Text Phease => _phease;
    public Sprite Icon => _icon;

    public void UpdateLocalization()
    {
        _localized.UpdateTranslation(LeanLocalization.GetTranslation(_localized.TranslationName));
    }
}