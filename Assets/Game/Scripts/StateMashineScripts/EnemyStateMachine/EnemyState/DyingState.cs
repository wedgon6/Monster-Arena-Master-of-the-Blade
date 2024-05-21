public class DyingState : EnemyState
{
    private void Update()
    {
        if (Enemy.IsDead)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        //Enemy.Dead();
        //PlayerMoney.AddMoney(Enemy.Revard);
        //PlayerScore.AddScore(Enemy.CountScore);
        //Enemy.Spawner.EnemyDead();
    }
}