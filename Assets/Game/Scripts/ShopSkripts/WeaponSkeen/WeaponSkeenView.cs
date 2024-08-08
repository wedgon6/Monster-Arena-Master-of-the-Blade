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

    private WorckshopItem _item;
    private int _indexBlade;

    public event Action<WorckshopItem, int> ActionButtonClick;

    public void Render(WorckshopItem item, int index)
    {
        _item = item;
        _item.Initialize(index);
    
        if (_item.IsUnlock)
        {
            _unlockStatus.sprite = _unlockImage;

            if (_item.IsSelect)
            {
                _unlockStatus.sprite = _selectImage;
            }
        }
        else
        {
            _unlockStatus.sprite = _lockImage;
        }

        _lable.text = item.Lable;
        _icon.sprite = item.Icon;

        _actionButton.onClick.AddListener(ClickButton);
        _item.UnlockedSkeen += OnBuySkeen;
        _item.SelectedSkeen += OnSelectedSkeen;
    }

    private void OnEnable()
    {
        if(_item != null)
        {
            _actionButton.onClick.AddListener(ClickButton);
            _item.UnlockedSkeen += OnBuySkeen;
            _item.SelectedSkeen += OnSelectedSkeen;
        }
    }

    private void OnDisable()
    {
        if (_item != null)
        {
            _actionButton.onClick.RemoveListener(ClickButton);
            _item.UnlockedSkeen -= OnBuySkeen;
            _item.SelectedSkeen -= OnSelectedSkeen;
        }
    }

    private void ClickButton()
    {
        ActionButtonClick?.Invoke(_item, _indexBlade);
    }

    private void OnBuySkeen()
    {
        if(_unlockStatus.sprite != null && _unlockImage != null)
        {
            _unlockStatus.sprite = _unlockImage;
        }
    }

    private void OnSelectedSkeen()
    {
        _unlockStatus.sprite = _selectImage;
    }
}