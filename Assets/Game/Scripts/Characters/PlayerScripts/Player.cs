using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerWallet _wallet;
    
    private float _maxHealth = 1000;
    private float _health;

    private Gold _gold = new Gold(0);
    private Daimond _daimond = new Daimond(0);

    public PlayerWallet PlayerWallet => _wallet;
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;

    public event Action<float, float> ChangeHealth;
    public event Action<float> TakedDamage;
    public event Action Died;

    public float GetCurrentHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        if (_health < 0)
            return;

        _health -= damage;
        TakedDamage?.Invoke(damage);
        ChangeHealth?.Invoke(_health, _maxHealth);

        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
    }

    private void Awake()
    {
        _wallet.Initialize(_gold.Value, _daimond.Value);
        _health = _maxHealth;
        ChangeHealth?.Invoke(_health, _maxHealth);
    }
}