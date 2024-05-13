using UnityEngine;

public class DyingTransition : Transition
{
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Debug.Log(_enemy.Health);
        if (_enemy.Health == 0)
            NeedTransit = true;
    }
}