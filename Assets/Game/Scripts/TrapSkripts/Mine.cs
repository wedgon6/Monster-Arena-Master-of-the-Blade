using MonsterArenaMasterOfTheBlade.Characters;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.TrapScripts
{
    public class Mine : Trap
    {
        [SerializeField] private GameObject _explosionEffect;

        protected override void ApplyDamage(IDamageable damageable)
        {
            damageable.TakeDamage(_damage);
            Instantiate(_explosionEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}