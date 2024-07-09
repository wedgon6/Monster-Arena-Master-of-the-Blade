using System;
using TMPro;
using UnityEngine;

public class WorckshopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _startPrice;
    //[SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

    private bool _isUnlock;
    private bool _isSelect;
    private int _price;

    public event Action PriceChanged;
    public event Action<TrainingItem> ButtonCliked;

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

    public void GetCloudData(bool isUnlock, bool isSelect)
    {
        if(isUnlock)
        {
            _isUnlock = true;
        }

        if (isSelect)
        {
            _isSelect = true;
        }
    }
}