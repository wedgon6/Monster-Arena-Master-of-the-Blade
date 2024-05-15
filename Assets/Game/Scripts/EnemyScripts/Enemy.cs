using UnityEngine;

public class Enemy : PoolObject
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private Player _target;

    private float _health;
    private bool _isDead;

    public float Health => _health;
    public bool IsDead => _isDead;
    public Player Target => _target;

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

        if (_health <= 0)
        {
            _health = 0;
            _isDead = true;
        }
    }

    private void Awake()
    {
        _health = _maxHealth;
    }
}