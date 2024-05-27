using UnityEngine;

public class MovmentState : EnemyState
{
    [SerializeField] private float _moveSpeed = 0.5f;
    [SerializeField] private float _maxSpeed = 4f;
    private Vector3 _direction;

    public override void Enter()
    {
        base.Enter();
        MoveEvent();
    }

    public override void Exit()
    {
        RigidbodyEnemy.velocity = Vector3.zero;
        base.Exit();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.LookAt(Target.transform.position);
        transform.position = Vector3.Lerp(transform.position, Target.transform.position, _moveSpeed * Time.fixedDeltaTime);

        _direction = new Vector3(Target.transform.position.x, 0, Target.transform.position.z);
        RigidbodyEnemy.AddForce(_direction * _moveSpeed);
        _direction = Vector3.zero;

        if (RigidbodyEnemy.velocity.y < 0f)
        {
            RigidbodyEnemy.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        }

        Vector3 horizontalVelocity = RigidbodyEnemy.velocity;
        horizontalVelocity.y = 0;

        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
        {
            RigidbodyEnemy.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * RigidbodyEnemy.velocity.y;
        }
    }
}