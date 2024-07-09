using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkeenViewConteiner : MonoBehaviour
{
    [SerializeField] private TMP_Text _lable;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;

    private WorckshopItem _item;

    public void RenderChoiceSkeen(WorckshopItem item)
    {
        _lable.text = item.Lable;
        _price.text = item.Price.ToString();
        _icon.sprite = item.Icon;
    }
}