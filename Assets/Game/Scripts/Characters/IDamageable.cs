using System;
using UnityEngine;

public interface IDamageable 
{
    public event Action<float, float> ChangeHealth;
    public event Action<float> TakedDamage;
    public event Action<Transform> Died;
    public void TakeDamage(float damage);
    public float GetCurrentHealth();
    public float GetMaxHealth();
}