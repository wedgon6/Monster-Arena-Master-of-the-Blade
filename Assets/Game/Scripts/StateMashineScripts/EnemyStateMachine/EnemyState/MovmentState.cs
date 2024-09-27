using UnityEngine;
using UnityEngine.AI;

namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    public class MovmentState : EnemyState
    {
        [SerializeField] private float _moveSpeed = 0.5f;
        [SerializeField] private float _maxSpeed = 4f;

        private NavMeshAgent _agent;

        public override void Enter()
        {
            base.Enter();
            _agent.speed = _moveSpeed;
            MoveEvent();
        }

        public override void Exit()
        {
            _agent.speed = 0;
            base.Exit();
        }

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _agent.SetDestination(Vector3.forward + Target.transform.position);
        }
    }
}