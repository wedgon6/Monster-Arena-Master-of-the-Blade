namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    public class WinState : EnemyState
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            EnemyWinEvent();
        }
    }
}