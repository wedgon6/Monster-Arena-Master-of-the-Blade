using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Movment _playerMovment;
    [SerializeField] private BladeSpawner _bladeSpawner;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private float _maxSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _maxSpeed = _playerMovment.MaxMoveSpeed;
    }
    private void OnEnable()
    {
        _bladeSpawner.ThrowingBlade += OnThrowBladeAnimation;
    }

    private void OnDisable()
    {
        _bladeSpawner.ThrowingBlade -= OnThrowBladeAnimation;
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.magnitude / _maxSpeed);
    }

    private void OnThrowBladeAnimation()
    {
        _animator.SetTrigger("OnThrow");
    }
}