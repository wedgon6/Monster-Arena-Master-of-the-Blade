using UnityEngine;

public class TakeDamageState : EnemyState
{
    public override void Enter()
    {
        if (enabled == false)
        {
            enabled = true;
            OnEnter();
        }

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

    private void EnebleTransition()
    {
        foreach (var transition in _transitions)
        {
            transition.enabled = true;
        }
    }
}