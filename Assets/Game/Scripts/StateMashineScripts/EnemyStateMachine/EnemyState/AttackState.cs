using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] private int _damage;
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
                AttackEvent();
                _lastAttackTime = _attackDelay;
            }
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void ApplyDamage()
    {
        Target.TakeDamage(_damage);
    }
}