using MonsterArenaMasterOfTheBlade.Characters;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    [RequireComponent(typeof(Enemy))]
    public class MovmentTransition : Transition
    {
        [SerializeField] private float _distance = 3f;

        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void Update()
        {
            Vector3 directionToTarget = transform.position - _enemy.Target.transform.position;
            float distance = directionToTarget.magnitude;

            if (distance > _distance)
                NeedTransit = true;
        }
    }
}