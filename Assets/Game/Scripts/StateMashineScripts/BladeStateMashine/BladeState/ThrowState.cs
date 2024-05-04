using DG.Tweening;
using UnityEngine;

public class ThrowState : BladeState
{
    private Tween _throw;
    private Vector3 _direction;

    public override void Enter()
    {
        base.Enter();
        _direction = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
        _throw = transform.DOMove(_direction, 3f).SetEase(Ease.Linear).OnComplete(OnNeedBack);
    }

    private void Update()
    {
        //transform.position = Vector3.Lerp(_direction, transform.position, 3f);
        //if(transform.position == _direction)
        //    _blade.TryRebound();
    }

    private void FixedUpdate()
    {
        if (_throw.IsComplete() || _throw == null)
        {
            _blade.TryRebound();
        }
    }

    private void OnNeedBack()
    {
        _blade.TryRebound();
    }
}