using UnityEngine;

public class Enemy : PoolObject
{
    [SerializeField] private float _maxHealth;

    private float _health;
    private bool _isDead;

    public float Health => _health;
    public bool IsDead => _isDead;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        if (_health < 0)
            return;

        _health -= damage;

        if (_health < 0)
        {
            _health = 0;
            _isDead = true;
        }
        Debug.Log("Damage");
    }
}