using MonsterArenaMasterOfTheBlade.StateMashineScripts;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.Characters
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Enemy))]
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private List<EnemyState> _enemyStates;

        private Animator _animator;
        private Enemy _enemy;
        private HashAnimationEnemy _animationEnemy = new HashAnimationEnemy();

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
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

        private void OnMove() => _animator.SetTrigger(_animationEnemy.MoveAnimation);

        private void OnAttack() => _animator.SetTrigger(_animationEnemy.AttackAnimation);

        private void OnTakeDamage() => _animator.SetTrigger(_animationEnemy.TakeDamageAnimation);

        private void OnWinGame() => _animator.SetTrigger(_animationEnemy.WinDanceAnimation);
    }
}