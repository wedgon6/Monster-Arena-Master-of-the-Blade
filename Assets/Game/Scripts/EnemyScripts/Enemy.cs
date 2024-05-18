using System;
using UnityEngine;

public class Enemy : PoolObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Player _target;

    private float _health;
    private bool _isDead;
    private Gold _gold = new Gold(5);
    private Daimond _daimond = new Daimond(1);

    public float Health => _health;
    public bool IsDead => _isDead;
    public Player Target => _target;

    public event Action ChengetHealt;

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
        ChengetHealt?.Invoke();

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
    }
}