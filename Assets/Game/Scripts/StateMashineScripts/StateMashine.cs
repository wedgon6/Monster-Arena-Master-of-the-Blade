using UnityEngine;

public class StateMashine : MonoBehaviour
{
    [SerializeField] protected State _firstState;

    private State _currentState;

    protected virtual void UpdateStateStatus()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetNextState();

        if (nextState != null)
            Transit(nextState);
    }

    protected void EnterState(State state)
    {
        _currentState = state;

        if (_currentState != null)
            _currentState.Enter();
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}