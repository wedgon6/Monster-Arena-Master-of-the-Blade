using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSkeen", menuName = "ScriptableObjects/WeaponSkeen")]
public class WeaponSkeenData : ScriptableObject
{
    [SerializeField] private string _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _startPrice;
    [SerializeField] private Blade _blade;
    [SerializeField] private string _localizedKey;

    public string Lable => _lable;
    public Sprite Icon => _icon;
    public Blade Blade => _blade;
    public int Price => _startPrice;
    public string LocalizedKey => _localizedKey;
}