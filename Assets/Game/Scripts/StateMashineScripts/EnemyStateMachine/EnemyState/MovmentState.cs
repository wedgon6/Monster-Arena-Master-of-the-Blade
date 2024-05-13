using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class MovmentState : EnemyState
{
    private NavMeshAgent _agent;

    public override void Enter()
    {
        base.Enter();
        MoveEvent();
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        _agent.SetDestination(Vector3.forward + Target.transform.position);
    }
}