using Lean.Localization;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterArenaMasterOfTheBlade.ShopScripts
{
    public class WeaponSkeenViewConteiner : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lable;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _actionButton;
        [SerializeField] private GameObject _priceContent;
        [SerializeField] private GameObject _selecteContent;
        [SerializeField] private GameObject _selectedContent;
        [SerializeField] private LeanLocalizedTextMeshProUGUI _localized;

        private WeaponSkeenView _item;
        private int _indexCurrentSkeen;

        public event Action<WeaponSkeenView> ClickBuyButton;
        public event Action<WeaponSkeenView, int> ClickSelectSkeenButton;

        public void RenderChoiceSkeen(WeaponSkeenView item)
        {
            SetNewItem();

            if (_item != null)
            {
                _item.UnlockedSkeen -= OnSkeenBuy;
                _item.SelectedSkeen -= OnSkeenSelect;
            }

            _item = item;
            _indexCurrentSkeen = _item.Index;
            _localized.TranslationName = _item.LocalizationKey;
            _price.text = _item.Price.ToString();
            _icon.sprite = _item.Icon;
            _item.UnlockedSkeen += OnSkeenBuy;
            _item.SelectedSkeen += OnSkeenSelect;
            _priceContent.SetActive(true);

            if (_item.IsUnlock)
            {
                _priceContent.SetActive(false);
                _selecteContent.SetActive(true);

                if (_item.IsSelect)
                {
                    _selecteContent.SetActive(false);
                    _selectedContent.SetActive(true);
                    return;
                }

                _actionButton.onClick.AddListener(OnClickSelectSkeen);
                return;
            }

            _actionButton.onClick.AddListener(OnClickBuySkeen);
        }

        private void OnEnable()
        {
            if (_item != null)
            {
                _item.UnlockedSkeen += OnSkeenBuy;
                _item.SelectedSkeen += OnSkeenSelect;
            }
        }

        private void OnDisable()
        {
            if (_item != null)
            {
                _item.UnlockedSkeen -= OnSkeenBuy;
                _item.SelectedSkeen -= OnSkeenSelect;
            }
        }

        private void SetNewItem()
        {
            _selecteContent.SetActive(false);
            _selectedContent.SetActive(false);
            _actionButton.onClick.RemoveAllListeners();
        }

        private void OnClickBuySkeen()
        {
            ClickBuyButton?.Invoke(_item);
        }

        private void OnClickSelectSkeen()
        {
            ClickSelectSkeenButton?.Invoke(_item, _indexCurrentSkeen);
        }

        private void OnSkeenBuy()
        {
            _priceContent.SetActive(false);
            _selecteContent.SetActive(true);
            _actionButton.onClick.RemoveListener(OnClickBuySkeen);
            _actionButton.onClick.AddListener(OnClickSelectSkeen);
        }

        private void OnSkeenSelect()
        {
            _selecteContent.SetActive(false);
            _selectedContent.SetActive(true);
            _actionButton.onClick.RemoveAllListeners();
        }
    }
}