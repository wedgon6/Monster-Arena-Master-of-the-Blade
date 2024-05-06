using DG.Tweening;
using UnityEngine;

public class ThrowState : BladeState
{
    private Tween _throw;

    public override void Enter()
    {
        base.Enter();
        //_throw = transform.DOMove(_blade.Direction, 2f).SetEase(Ease.Linear).OnComplete(OnNeedBack);
    }

    public override void Exit()
    {
        base.Exit();
        _throw.Restart();
    }

    private void FixedUpdate()
    {
        //if (_throw.IsComplete() || _throw == null)
        //{
        //    _blade.TryRebound();
        //}

        //if((int)transform.position.z == (int)_blade.Direction.z)
        //{
        //    _blade.TryRebound();
        //}

        //transform.position = Vector3.Lerp(transform.position, _blade.Direction, 2f * Time.fixedDeltaTime);
    }

    private void OnNeedBack()
    {
        _blade.TryRebound();
    }
}