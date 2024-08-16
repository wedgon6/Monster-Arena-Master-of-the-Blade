using Lean.Localization;
using System;
using TMPro;
using UnityEngine;

public class TrainingItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _multiplier;
    [SerializeField] private int _startPrice;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

    private int _currentPrice;
    private int _currentLvl = 0;

    public event Action PriceChanged;
    public event Action<TrainingItem> ButtonCliked;

    protected float Multiplier => _multiplier;
    protected int CurrentPrice => _currentPrice;

    public string Lable => _lable.text;
    public Sprite Icon => _icon;
    public int Price => _currentPrice;

    public void Initialize()
    {
        _localized.UpdateTranslation(LeanLocalization.GetTranslation(_localized.TranslationName));
        _currentPrice = _startPrice;
        PriceChanged?.Invoke();
    }

    public void GetCloudData(int currentPrice)
    {
        _currentPrice = currentPrice;
        PriceChanged?.Invoke();
    }

    public virtual void Buy(ParametersPlayer parametersPlayer)
    {
        ButtonCliked?.Invoke(this);
        _currentPrice = (int)Math.Round(CurrentPrice * Multiplier, 0);
        PriceChanged?.Invoke();
    }
}