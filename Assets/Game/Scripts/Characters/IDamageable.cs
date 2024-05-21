using System;

public interface IDamageable 
{
    public event Action<float, float> ChangeHealth;
    public event Action<float> TakedDamage;
    public void TakeDamage(float damage);
    public float GetCurrentHealth();
    public float GetMaxHealth();
}