using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : PoolObject, IDamageable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private EnemyStateMachine _stateMachine;
    [SerializeField] private TypeEnemy _typeEnemy;

    private Player _target;
    private float _health;
    private Gold _gold = new Gold(5);
    private Daimond _daimond = new Daimond(1);
    private Rigidbody _rigidbody;
    private EnemySpawner _spawner;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _health;
    public Player Target => _target;
    public Rigidbody Rigidbody => _rigidbody;
    public EnemySpawner Spawner => _spawner;
    public string TypeEnemy => _typeEnemy.ToString();


    public event Action<float, float> ChangeHealth;
    public event Action<float> TakedDamage;
    public event Action GotHit;
    public event Action Died;

    public void ResetState() => _stateMachine.ResetStete();

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
        _target = player;
        _spawner = spawner;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        if (_health < 0)
            return;

        _health -= damage;
        GotHit?.Invoke();
        TakedDamage?.Invoke(damage);;
        ChangeHealth?.Invoke(_health,_maxHealth);

        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
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