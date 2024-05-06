using DG.Tweening;
using UnityEngine;

public class BacToPlayerState : BladeState
{
    private Tweener _throw;
    private Vector3 _target;
    private Vector3 _lastTargetPosition;

    public override void Enter()
    {
        base.Enter();
        _target = _bladeSpawner.transform.position;
        _throw = transform.DOMove(_target, 1f).SetEase(Ease.Linear).SetAutoKill(false);
        _lastTargetPosition = _target;
    }

    private void FixedUpdate()
    {
        if (_lastTargetPosition != _bladeSpawner.transform.position)
        {
            _target = _bladeSpawner.transform.position;
            _throw.ChangeEndValue(_target, true).Restart();
            _lastTargetPosition = _target;
        }
    }
}