using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _attackRange;
    [SerializeField] protected int _damage;

    private float _lastAttackTime = 0;

    public override void Enter()
    {
        base.Enter();
    }

    protected virtual bool Attack()
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (distance <= _attackRange)
        {
            if (_lastAttackTime <= 0)
            {
                _lastAttackTime = _attackDelay;
                return true;
            }
        }

        _lastAttackTime -= Time.deltaTime;
        return false;
    }

    private void Update()
    {
        if (Attack())
        {
            AttackEvent();
        }
    }

    private void ApplyDamage()
    {
        Vector3 directionToTarget = transform.position - Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (distance <= _attackRange)
            Target.TakeDamage(_damage);
    }
}