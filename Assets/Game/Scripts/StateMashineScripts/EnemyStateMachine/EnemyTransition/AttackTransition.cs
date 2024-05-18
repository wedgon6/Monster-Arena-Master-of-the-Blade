using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackTransition : Transition
{
    [SerializeField] private float _transitionRange = 3f;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 directionToTarget = transform.position - _enemy.Target.transform.position;
        float distance = directionToTarget.magnitude;

        if (distance <= _transitionRange)
        {
            NeedTransit = true;
        }
    }
}