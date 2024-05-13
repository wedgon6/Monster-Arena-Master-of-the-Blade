using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackTransition : Transition
{
    [SerializeField] private float _transitionRange;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Vector3 directionToTarget = transform.position - _enemy.Target.transform.position;
        float distance = directionToTarget.magnitude;
        Debug.Log(distance);
        if (distance < _transitionRange)
        {
            NeedTransit = true;
        }
    }
}