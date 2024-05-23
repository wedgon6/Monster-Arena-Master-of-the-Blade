using System;
using UnityEngine;

public class EnemyState : State
{
    private Enemy _enemy;

    public event Action Attacking;
    public event Action Moving;
    public event Action TakedDamage;

    public Enemy Enemy => _enemy;

    protected Player Target { get; set; }
    protected Rigidbody RigidbodyEnemy { get; set; }
    //protected PlayerScore PlayerScore { get; set; }
    //protected PlayerMoney PlayerMoney { get; set; }

    protected override void OnEnter()
    {
        _enemy = GetComponent<Enemy>();
        Target = _enemy.Target;
        RigidbodyEnemy = _enemy.Rigidbody;
        //PlayerScore = _enemy.PlayerScore;
        //PlayerMoney = _enemy.PlayerMoney;
    }

    protected void AttackEvent()
    {
        Attacking?.Invoke();
    }

    protected void MoveEvent()
    {
        Moving?.Invoke();
    }

    protected void TakeDamageEvent()
    {
        TakedDamage?.Invoke();
    }
}