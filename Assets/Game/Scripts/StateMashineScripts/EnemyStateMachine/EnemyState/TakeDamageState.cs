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
        Debug.Log("TakeDamageEnter");
    }

    private void TakeDamage()
    {
        TakeDamageEvent();
    }

    private void EnebleTransition()
    {
        Debug.Log("EnebleTransition");
        foreach (var transition in _transitions)
        {
            transition.enabled = true;
        }
    }

    private void OnEnable()
    {
        
    }
}