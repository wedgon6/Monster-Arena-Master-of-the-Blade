using MonsterArenaMasterOfTheBlade.Characters;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    [RequireComponent(typeof(Enemy))]
    public class WinTransition : Transition
    {
        private Enemy _enemy;

        private void OnEnable()
        {
            NeedTransit = false;
            _enemy = GetComponent<Enemy>();
            _enemy.�elebratedWin += TransitWinState;
        }

        private void OnDisable() => _enemy.�elebratedWin -= TransitWinState;

        private void TransitWinState() => NeedTransit = true;
    }
}