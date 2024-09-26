using Lean.Localization;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSkeenView : MonoBehaviour
{
    [SerializeField] private Sprite _lockImage;
    [SerializeField] private Sprite _unlockImage;
    [SerializeField] private Sprite _selectImage;
    [SerializeField] private Image _unlockStatus;
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private Button _actionButton;
    [SerializeField] private LeanLocalizedTextMeshProUGUI _leanLocalizedTextMeshPro;

    private WeaponSkeenData _item;
    private int _indexBlade;
    private bool _isUnlock = false;
    private bool _isSelect = false;
    private int _price;

    public event Action<WeaponSkeenData, int, WeaponSkeenView> ActionButtonClick;
    public event Action UnlockedSkeen;
    public event Action SelectedSkeen;

    public bool IsUnlock => _isUnlock;
    public bool IsSelect => _isSelect;
    public int Price => _price;
    public int Index => _indexBlade;
    public string LocalizationKey => _item.LocalizedKey;
    public Sprite Icon => _item.Icon;
    public Blade Blade => _item.Blade;

    public void Render(WeaponSkeenData item, int index)
    {
        _item = item;
        _isUnlock = false;
        _isSelect = false;
        _price = item.Price;
        _indexBlade = index;

        _lable.text = _item.Lable;
        _icon.sprite = _item.Icon;
        _leanLocalizedTextMeshPro.TranslationName = _item.LocalizedKey;

        _actionButton.onClick.AddListener(ClickButton);
    }

    public void SetData(bool isUnlock, bool isSelect)
    {
        _isUnlock = isUnlock;
        _isSelect = isSelect;

        if (_isUnlock)
        {
            _unlockStatus.sprite = _unlockImage;

            if (_isSelect)
                _unlockStatus.sprite = _selectImage;
        }
        else
        {
            _unlockStatus.sprite = _lockImage;
        }
    }

    public void BuySkeen()
    {
        _isUnlock = true;
        SetUnlockImage();
        UnlockedSkeen?.Invoke();
    }

    public void RemoveSkeen()
    {
        _isSelect = false;
        SetUnlockImage();
    }

    public void SetSkeen()
    {
        if (_isUnlock == false)
            return;

        _isSelect = true;
        _unlockStatus.sprite = _selectImage;
        SelectedSkeen?.Invoke();
    }

    private void OnEnable()
    {
        if (_item != null)
            _actionButton.onClick.AddListener(ClickButton);
    }

    private void OnDisable()
    {
        if (_item != null)
            _actionButton.onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        ActionButtonClick?.Invoke(_item, _indexBlade, this);
    }

    private void SetUnlockImage()
    {
        if (_unlockStatus.sprite != null && _unlockImage != null)
            _unlockStatus.sprite = _unlockImage;
    }
}