using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Movment _playerMovment;
    [SerializeField] private BladeSpawner _bladeSpawner;
    [SerializeField] private Player _player;

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
        _player.Died += OnDead;
    }

    private void OnDisable()
    {
        _bladeSpawner.ThrowingBlade -= OnThrowBladeAnimation;
        _player.Died -= OnDead;
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.magnitude / _maxSpeed);
    }

    private void OnThrowBladeAnimation()
    {
        _animator.SetTrigger("OnThrow");
    }

    private void OnDead(Transform transform)
    {
        _animator.SetTrigger("IsDead");
    }
}