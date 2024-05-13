public class EnemyStateMachine : StateMashine
{
    public void ResetStete()
    {
        EnterState(_firstState);
    }

    private void Start()
    {
        EnterState(_firstState);
    }

    private void Update()
    {
        UpdateStateStatus();
    }
}