using MonsterArenaMasterOfTheBlade.PoolSystem;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.Characters
{
    public class EnemyBullet : PoolObject
    {
        private int _damage = 15;

        public void Initialaze(int damage)
        {
            _damage = damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                player.TakeDamage(_damage);
                ReturObjectPool();
            }

            if (collision.collider.TryGetComponent(out Wall wall))
            {
                ReturObjectPool();
            }
        }
    }
}