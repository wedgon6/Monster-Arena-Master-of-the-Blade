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
        //Enemy.Dead();
        Destroy(gameObject);
        //PlayerMoney.AddMoney(Enemy.Revard);
        //PlayerScore.AddScore(Enemy.CountScore);
        //Enemy.Spawner.EnemyDead();
    }
}