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
    
        if (item.IsUnlock)
        {
            _unlockStatus.sprite = _unlockImage;
        }
        else
        {
            _unlockStatus.sprite = _lockImage;
        }

        _lable.text = item.Lable;
        _icon.sprite = item.Icon;

        _actionButton.onClick.AddListener(ClickButton);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(ClickButton);
    }

    private void ClickButton()
    {
        ActionButtonClick?.Invoke(_item);
    }
}