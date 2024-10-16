namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    public class DyingState : EnemyState
    {
        private void Update()
        {
            if (Enemy.IsDead)
                Die();
        }

        private void Die()
        {
            Enemy.Die();
            Target.PlayerWallet.AddMoney(Enemy.Gold, Enemy.Daimond);
            Target.AddScore();
        }
    }
}