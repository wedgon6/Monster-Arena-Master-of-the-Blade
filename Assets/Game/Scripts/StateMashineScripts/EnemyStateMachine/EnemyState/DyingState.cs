public class DyingState : EnemyState
{
    private void OnEnable()
    {
        Enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        Enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        Destroy(gameObject);
        //Enemy.Dead();
        //PlayerMoney.AddMoney(Enemy.Revard);
        //PlayerScore.AddScore(Enemy.CountScore);
        //Enemy.Spawner.EnemyDead();
    }
}