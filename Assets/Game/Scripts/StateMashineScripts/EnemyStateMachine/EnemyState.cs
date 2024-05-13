using System;

public class EnemyState : State
{
    private Enemy _enemy;

    public event Action Attacking;
    public event Action Moving;

    public Enemy Enemy => _enemy;

    protected Player Target { get; set; }
    //protected PlayerScore PlayerScore { get; set; }
    //protected PlayerMoney PlayerMoney { get; set; }

    protected override void OnEnter()
    {
        _enemy = GetComponent<Enemy>();
        Target = _enemy.Target;
        //PlayerScore = _enemy.PlayerScore;
        //PlayerMoney = _enemy.PlayerMoney;
    }

    protected void AttackEvent()
    {
        Attacking?.Invoke();
    }

    protected void MoveEvent()
    {
        Moving?.Invoke();
    }
}