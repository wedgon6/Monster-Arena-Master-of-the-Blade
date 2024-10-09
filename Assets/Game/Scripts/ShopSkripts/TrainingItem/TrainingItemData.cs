using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.ShopScripts
{
    [CreateAssetMenu(fileName = "TrainingItemData", menuName = "ScriptableObjects/TrainingItemData")]
    public class TrainingItemData : ScriptableObject
    {
        [SerializeField] private string _lable;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _multiplier;
        [SerializeField] private int _startPrice;
        [SerializeField] private string _localizedKey;
        [SerializeField] private TypePlayerStats _typeStats;

        public float Multiplier => _multiplier;
        public string Lable => _lable;
        public Sprite Icon => _icon;
        public int StartPrice => _startPrice;
        public string LocalizateKey => _localizedKey;
        public string TypePlayerStats => _typeStats.ToString();
    }
}