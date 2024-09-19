using Lean.Localization;
using TMPro;
using UnityEngine;

public class TrainingItemData : ScriptableObject
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _multiplier;
    [SerializeField] private int _startPrice;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

    protected float Multiplier => _multiplier;

    public TMP_Text Lable => _lable;
    public Sprite Icon => _icon;
    public int StartPrice => _startPrice;
    public LeanLocalizedTextMeshProUGUI Localizate => _localized;
}