using DG.Tweening;
using UnityEngine;

public class TakeDamageState : EnemyState
{
    public override void Enter()
    {
        base.Enter();
        TakeDamage();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void TakeDamage()
    {
        TakeDamageEvent();
    }
}