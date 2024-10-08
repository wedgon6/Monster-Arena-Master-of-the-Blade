using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    public class AttackState : EnemyState
    {
        [SerializeField] private float _attackDelay;
        [SerializeField] private float _attackRange;
        [SerializeField] protected int _damage;

        private float _lastAttackTime = 0;

        private void Update()
        {
            if (Attack())
            {
                AttackEvent();
            }
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            _lastAttackTime = 0f;
            base.Exit();
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

        private void ApplyDamage()
        {
            Vector3 directionToTarget = transform.position - Target.transform.position;
            float distance = directionToTarget.magnitude;

            if (distance <= _attackRange)
                Target.TakeDamage(_damage);
        }
    }
}