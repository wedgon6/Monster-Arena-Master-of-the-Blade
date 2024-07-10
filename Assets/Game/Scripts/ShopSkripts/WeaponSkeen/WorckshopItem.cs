using System;
using TMPro;
using UnityEngine;

public class WorckshopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _startPrice;
    [SerializeField] private Blade _blade;
    //[SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

    private bool _isUnlock;
    private bool _isSelect;
    private int _price;

    public event Action PurchasedSkeen;
    public event Action SelectedSkeen;
    public event Action PriceChanged;
    public event Action<TrainingItem> ButtonCliked;

    public Blade Blade => _blade;
    public bool IsUnlock => _isUnlock;
    public bool IsSelect => _isSelect;
    public string Lable => _lable.text;
    public Sprite Icon => _icon;
    public int Price => _price;

    public void Initialize()
    {
        //_localized.UpdateTranslation(LeanLocalization.GetTranslation(_localized.TranslationName));
        _price = _startPrice;
        PriceChanged?.Invoke();
    }

    public void GetData(bool isUnlock, bool isSelect)
    {
        if(isUnlock)
        {
            _isUnlock = true;
            PurchasedSkeen?.Invoke();
        }

        if (isSelect)
        {
            _isSelect = true;
            SelectedSkeen?.Invoke();
        }

        Debug.Log("GetData");
    }

    public void BuySkeen()
    {
        _isUnlock = true;
        PurchasedSkeen?.Invoke();
    }
}