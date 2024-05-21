using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : PoolObject, IDamageable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Player _target;

    private float _health;
    private bool _isDead;
    private Gold _gold = new Gold(5);
    private Daimond _daimond = new Daimond(1);

    private Rigidbody _rigidbody;
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;
    public bool IsDead => _isDead;
    public Player Target => _target;
    public Rigidbody Rigidbody => _rigidbody;


    public event Action<float, float> ChangeHealth;
    public event Action<float> TakedDamage;

    public float GetCurrentHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public void Initialize()
    {

    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        if (_health < 0)
            return;

        _health -= damage;
        TakedDamage?.Invoke(damage);
        Vector3 direction = (transform.position - Target.transform.position).normalized;
        _rigidbody.AddForce(direction * 100f, ForceMode.VelocityChange);
        Debug.Log(direction);
        ChangeHealth?.Invoke(_health,_maxHealth);

        if (_health <= 0)
        {
            _health = 0;
            _isDead = true;
            _target.PlayerWallet.AddMoney(_gold, _daimond);
        }
    }

    private void Awake()
    {
        _health = _maxHealth;
        _rigidbody = GetComponent<Rigidbody>();
        ChangeHealth?.Invoke(_health, _maxHealth);
    }
}