using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.Weapon;
using System;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.SaveSystem
{
    public class ParametersPlayer : MonoBehaviour
    {
        [SerializeField] private float _healthStep = 20f;
        [SerializeField] private float _moveSpeedStep = 0.03f;
        [SerializeField] private float _damageStep = 5f;
        [SerializeField] private float _rangeThrowStep = 0.3f;

        private float _maxPlayerHealth;
        private float _playerMoveSpeed;
        private float _damage;
        private float _rangeThrow;
        private int _score;
        private Blade _blade;
        private PlayerStandartParametrs _standartParametrs = new PlayerStandartParametrs();

        public event Action SavedData;

        public float MaxPlayerHealth => _maxPlayerHealth;
        public float PlayerMoveSpeed => _playerMoveSpeed;
        public float Damage => _damage;
        public float RangeThrow => _rangeThrow;
        public int Score => _score;

        public void Initialize()
        {
            _maxPlayerHealth = _standartParametrs.StartHealth;
            _playerMoveSpeed = _standartParametrs.StartMoveSpeed;
            _damage = _standartParametrs.StartDamage;
            _rangeThrow = _standartParametrs.StartRangeThrow;
            _score = _standartParametrs.StartScore;
        }

        public void Initialize(GameInfo data)
        {
            _maxPlayerHealth = data.MaxPlayerHealth;
            _playerMoveSpeed = data.PlayerMoveSpeed;
            _damage = data.Damage;
            _rangeThrow = data.RangeThrow;
            _score = data.PlayerScore;
        }

        public void AddMaxHealth()
        {
            _maxPlayerHealth += _healthStep;
            SavedData?.Invoke();
        }

        public void AddMoveSpeed()
        {
            _playerMoveSpeed += _moveSpeedStep;
            SavedData?.Invoke();
        }

        public void AddDamage()
        {
            _damage += _damageStep;
            SavedData?.Invoke();
        }

        public void AddRangeThrow()
        {
            _rangeThrow += _rangeThrowStep;
            SavedData?.Invoke();
        }

        public void SelectWeaponSkeen(Blade blade)
        {
            _blade = blade;
        }
    }
}