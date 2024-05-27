using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class TakeDamageTransition : Transition
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        NeedTransit = false;
        _enemy.GotHit += OnTakeDamage;
    }

    private void OnDisable()
    {
        _enemy.GotHit -= OnTakeDamage;
    }

    private void OnTakeDamage()
    {
        NeedTransit = true;
    }
}