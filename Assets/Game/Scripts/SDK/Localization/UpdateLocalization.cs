using Lean.Localization;
using UnityEngine;

public class UpdateLocalization : MonoBehaviour
{
    [SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

    private void Start()
    {
        _localized.UpdateTranslation(LeanLocalization.GetTranslation(_localized.TranslationName));
    }
}