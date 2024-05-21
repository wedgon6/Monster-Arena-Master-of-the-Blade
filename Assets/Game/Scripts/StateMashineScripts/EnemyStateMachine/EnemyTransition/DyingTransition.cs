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
        if (_enemy.CurrentHealth == 0)
            NeedTransit = true;
    }
}