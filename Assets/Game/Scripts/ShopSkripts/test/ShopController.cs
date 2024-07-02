using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private ParametersPlayer _parameters;

    public void Initialize()
    {
        foreach (var shpoItem in _shop.PlayerAbillities)
        {
            shpoItem.ButtonCliked += OnClickButtonShopItem;
        }
    }

    private void OnDisable()
    {
        foreach (var shpoItem in _shop.PlayerAbillities)
        {
            shpoItem.ButtonCliked -= OnClickButtonShopItem;
        }
    }

    private void OnClickButtonShopItem(ShopItem item)
    {
        if(item.TryGetComponent<PlayerAbillity>(out PlayerAbillity abillity))
        {
            abillity.AddPlayerStats(_parameters);
        }

        if(item.TryGetComponent<WeaponViewItem>(out WeaponViewItem weaponView))
        {
            if (weaponView.IsUnlock)
            {
                weaponView.ÑhooseView(_parameters);
            }
            else
            {
                weaponView.UnlockView();
            }
        }
    }
}