using Lean.Localization;
using System;
using TMPro;
using UnityEngine;

public class WorckshopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _startPrice;
    [SerializeField] private Blade _blade;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

    private bool _isUnlock = false;
    private bool _isSelect = false;
    private int _price;
    private int _index;

    public event Action UnlockedSkeen;
    public event Action SelectedSkeen;
    public event Action PriceChanged;
    public event Action<TrainingItem> ButtonCliked;

    public Blade Blade => _blade;
    public string Lable => _lable.text;
    public Sprite Icon => _icon;
    public int Price => _price;
    public int Index => _index;
    public bool IsUnlock => _isUnlock;
    public bool IsSelect => _isSelect;

    public void Initialize(int index)
    {
        _localized.UpdateTranslation(LeanLocalization.GetTranslation(_localized.TranslationName));
        _isUnlock = false;
        _isSelect = false;
        _price = _startPrice;
        _index = index;
        PriceChanged?.Invoke();
    }

    public void SetData(bool isUnlock, bool isSelect)
    {
        if(isUnlock)
        {
            _isUnlock = true;
            UnlockedSkeen?.Invoke();
        }

        if (isSelect)
        {
            _isSelect = true;
            SelectedSkeen?.Invoke();
        }
    }

    public void BuySkeen()
    {
        _isUnlock = true;
        UnlockedSkeen?.Invoke();
    }

    public void SetSkeen()
    {
        if (_isUnlock == false)
            return;

        _isSelect = true;
        SelectedSkeen?.Invoke();
    }

    public void RemoveSkeen()
    {
        _isSelect = false;
        UnlockedSkeen?.Invoke();
    }

    private void Awake()
    {
        _isUnlock = false;
        _isSelect = false;
    }
}