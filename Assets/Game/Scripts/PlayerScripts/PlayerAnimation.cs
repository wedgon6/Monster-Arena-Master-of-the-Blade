using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Movment _playerMovment;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _maxSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _maxSpeed = _playerMovment.MaxMoveSpeed;
    }
    private void Update()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.magnitude / _maxSpeed);
    }
}