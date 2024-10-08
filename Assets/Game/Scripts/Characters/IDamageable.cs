using System;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.Characters
{
    public interface IDamageable
    {
        public event Action<float, float> HealthChanged;
        public event Action<float> TakedDamage;
        public event Action<Transform> Died;
        public void TakeDamage(float damage);
        public float GetCurrentHealth();
        public float GetMaxHealth();
    }
}