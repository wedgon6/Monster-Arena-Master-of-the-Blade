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
        _maxSpeed = _playerMovment.MoveSpeed;
        Debug.Log($"{_maxSpeed}");
    }
    private void OnEnable()
    {
        _bladeSpawner.ThrowingBlade += OnThrowBladeAnimation;
        _player.Died += OnDead;
        _player.Wined += OnDance;
    }

    private void OnDisable()
    {
        _bladeSpawner.ThrowingBlade -= OnThrowBladeAnimation;
        _player.Wined -= OnDance;
        _player.Died -= OnDead;
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.magnitude / (_maxSpeed * 2f) + 0.1f);
    }

    private void OnThrowBladeAnimation()
    {
        _animator.SetTrigger("OnThrow");
    }

    private void OnDead(Transform transform)
    {
        _animator.SetTrigger("IsDead");
    }

    private void OnDance()
    {
        _animator.SetTrigger("Win");
    }
}