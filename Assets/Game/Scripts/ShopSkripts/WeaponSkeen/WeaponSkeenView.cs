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

    public event Action<WorckshopItem> ActionButtonClick;

    public void Render(WorckshopItem item)
    {
        _item = item;
        _item.Initialize();
    
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
        _item.PurchasedSkeen += OnBuySkeen;
        _item.SelectedSkeen += OnSelectedSkeen;
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(ClickButton);
        _item.PurchasedSkeen -= OnBuySkeen;
        _item.SelectedSkeen -= OnSelectedSkeen;
    }

    private void ClickButton()
    {
        ActionButtonClick?.Invoke(_item);
    }

    private void OnBuySkeen()
    {
        _unlockStatus.sprite = _unlockImage;
    }

    private void OnSelectedSkeen()
    {
        _unlockStatus.sprite = _selectImage;
        Debug.Log("Поставил галочку");
    }
}