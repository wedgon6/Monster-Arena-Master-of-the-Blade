using MonsterArenaMasterOfTheBlade.MoneyScripts;
using MonsterArenaMasterOfTheBlade.PoolSystem;
using MonsterArenaMasterOfTheBlade.StateMashineScripts;
using System;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.Characters
{
    public class Enemy : PoolObject, IDamageable
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private EnemyStateMachine _stateMachine;
        [SerializeField] private TypeEnemy _typeEnemy;
        [SerializeField] private int _goldRewardCount = 2500;
        [SerializeField] private int _daimondRewardCount = 1;

        private Player _target;
        private float _health;
        private Gold _gold;
        private Daimond _daimond;
        private Rigidbody _rigidbody;
        private EnemySpawner _spawner;
        private bool _isDead;

        public Gold Gold => _gold;
        public Daimond Daimond => _daimond;
        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _health;
        public bool IsDead => _isDead;
        public Player Target => _target;
        public Rigidbody Rigidbody => _rigidbody;
        public string TypeEnemy => _typeEnemy.ToString();

        public event Action<float, float> HealthChanged;
        public event Action<float> TakedDamage;
        public event Action GotHit;
        public event Action<Transform> Died;
        public event Action ÑelebratedWin;
        public event Action StateMashineReseted;

        private void OnDisable()
        {
            _spawner.PlayerLose -= OnÑelebratDance;
        }

        public void ResetState()
        {
            _stateMachine.ResetStete();
            StateMashineReseted?.Invoke();
        }

        public float GetCurrentHealth()
        {
            return _health;
        }

        public float GetMaxHealth()
        {
            return _maxHealth;
        }

        public void Initialize(Player player, EnemySpawner spawner)
        {
            _gold = new Gold(_goldRewardCount);
            _daimond = new Daimond(_daimondRewardCount);
            _health = _maxHealth;
            _target = player;
            _spawner = spawner;
            HealthChanged?.Invoke(_health, _maxHealth);
            _spawner.PlayerLose += OnÑelebratDance;
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
                return;

            if (_health < 0)
                return;

            _health -= damage;
            GotHit?.Invoke();
            TakedDamage?.Invoke(damage); ;
            HealthChanged?.Invoke(_health, _maxHealth);

            if (_health <= 0)
            {
                _health = 0;
                _isDead = true;
            }
        }

        public void Die()
        {
            ReturnToPool();
            Died?.Invoke(transform);
        }

        protected override void ReturnToPool()
        {
            base.ReturnToPool();
            _isDead = false;
            _health = _maxHealth;
        }

        private void OnÑelebratDance()
        {
            ÑelebratedWin?.Invoke();
        }
    }
}