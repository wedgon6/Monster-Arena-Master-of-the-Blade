using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private List<EnemyState> _enemyStates;

    private Animator _animator;
    private Enemy _enemy;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
        _enemy.ResetStateMashine += OnMove;

        foreach (var events in _enemyStates)
        {
            events.Moving += OnMove;
            events.Attacking += OnAttack;
            events.TakedDamage += OnTakeDamage;
            events.PlayerLose += OnWinGame;
        }
    }

    private void OnDisable()
    {
        _enemy.ResetStateMashine -= OnMove;

        foreach (var events in _enemyStates)
        {
            events.Moving -= OnMove;
            events.Attacking -= OnAttack;
            events.TakedDamage -= OnTakeDamage;
            events.PlayerLose -= OnWinGame;
        }
    }

    private void OnMove() => _animator.SetTrigger("Move");

    private void OnAttack() => _animator.SetTrigger("Attack");

    private void OnTakeDamage() => _animator.SetTrigger("TakeDamage");

    private void OnWinGame() => _animator.SetTrigger("Win");
}