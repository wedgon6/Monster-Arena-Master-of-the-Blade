using System;

public class WeaponViewItem : ShopItem
{
    private bool _isUnlok = false;

    public bool IsUnlock => _isUnlok;

    public void �hooseView(ParametersPlayer parameters)
    {
        
    }

    public void UnlockView()
    {
        _isUnlok = true;
    }
}