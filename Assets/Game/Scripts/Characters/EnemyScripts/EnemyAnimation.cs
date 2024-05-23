using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private List<EnemyState> _enemyStates;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        foreach (var events in _enemyStates)
        {
            events.Moving += OnMove;
            events.Attacking += OnAttack;
            events.TakedDamage += OnTakeDamage;
        }
    }

    private void OnDisable()
    {
        foreach (var events in _enemyStates)
        {
            events.Moving -= OnMove;
            events.Attacking -= OnAttack;
            events.TakedDamage -= OnTakeDamage;
        }
    }

    private void OnMove() => _animator.SetTrigger("Move");

    private void OnAttack() => _animator.SetTrigger("Attack");

    private void OnTakeDamage() => _animator.SetTrigger("TakeDamage");
}