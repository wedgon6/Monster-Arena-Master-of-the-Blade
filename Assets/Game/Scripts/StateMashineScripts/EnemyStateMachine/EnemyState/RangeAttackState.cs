using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.PoolSystem;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    public class RangeAttackState : AttackState
    {
        [SerializeField] private EnemyBullet _bullet;
        [SerializeField] private Pool _pool;
        [SerializeField] protected Transform _shootPoint;

        public override void Enter()
        {
            base.Enter();
        }

        private void Update()
        {
            transform.LookAt(Target.transform.position);

            if (Attack())
                AttackEvent();
        }

        private void LaunchBullet()
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            EnemyBullet bullet;

            if (_pool.TryPoolObject(out PoolObject pollBullet))
            {
                bullet = pollBullet as EnemyBullet;
                bullet.transform.position = _shootPoint.transform.position;
                bullet.transform.rotation = _shootPoint.transform.rotation;
                bullet.gameObject.SetActive(true);
            }
            else
            {
                bullet = Instantiate(_bullet, _shootPoint.transform.position, _shootPoint.transform.rotation);
                _pool.InstantiatePoolObject(bullet);
            }

            bullet.Initialaze(_damage);
            bullet.GetComponent<Rigidbody>().AddForce(_shootPoint.forward * 5f, ForceMode.Impulse);

            TransitionEneble();
        }

        private void TransitionEneble()
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
            }
        }
    }
}