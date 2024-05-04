public class BladeStateMashine : StateMashine
{
    private void Start()
    {
        EnterState(_firstState);
    }

    private void Update()
    {
        UpdateStateStatus();
    }
}