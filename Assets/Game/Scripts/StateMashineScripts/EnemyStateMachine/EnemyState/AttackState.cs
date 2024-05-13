using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] private int _damege;
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackRange;

    private float _lastAttackTime = 0;

    private void Update()
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (distance <= _attackRange)
        {
            if (_lastAttackTime <= 0)
            {
                AttackPlayer(Target);
                _lastAttackTime = _attackDelay;
            }
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void AttackPlayer(Player player)
    {
        AttackEvent();
    }
}