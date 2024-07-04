public class DamageZone : Trap
{
    protected override void ApplyDamage(IDamageable damageable)
    {
        damageable.TakeDamage(_damage);
    }
}