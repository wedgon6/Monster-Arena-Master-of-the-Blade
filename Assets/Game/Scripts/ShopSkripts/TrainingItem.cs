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

    public event Action PriceChanged;
    public event Action<TrainingItem> ButtonCliked;

    protected float Multiplier => _multiplier;
    protected int CurrentPrice => _currentPrice;

    public TMP_Text Lable => _lable;
    public Sprite Icon => _icon;
    public int Price => _currentPrice;
    public LeanLocalizedTextMeshProUGUI Localizate => _localized;

    public void Initialize()
    {
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