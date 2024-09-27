using MonsterArenaMasterOfTheBlade.SaveSystem;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.ShopScripts
{
    public abstract class TrainingItemData : ScriptableObject
    {
        [SerializeField] private string _lable;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _multiplier;
        [SerializeField] private int _startPrice;
        [SerializeField] private string _localizedKey;

        public float Multiplier => _multiplier;
        public string Lable => _lable;
        public Sprite Icon => _icon;
        public int StartPrice => _startPrice;
        public string LocalizateKey => _localizedKey;

        public abstract void BuffPlayer(ParametersPlayer parametersPlayer);
    }
}