using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] protected float _damage;

    protected abstract void ApplyDamage(IDamageable damageable);

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.collider.TryGetComponent(out IDamageable damageable))
        {
           ApplyDamage(damageable);
        }
    }
}