using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blade : MonoBehaviour
{
    private BladeSpawner _bladeSpawner;
    private int _countRebound;
    private int _currentCountRebound;
    private bool _isReturn;

    public bool IsReturn => _isReturn;
    public BladeSpawner BladeSpawner => _bladeSpawner;

    public void Initialaze(Vector3 targetPoint, BladeSpawner bladeSpawner, int countRebound = 0)
    {
        _bladeSpawner = bladeSpawner;
        _countRebound = countRebound;
        _currentCountRebound = _countRebound;
        transform.DORotate(new Vector3(0, 360f, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }

    public bool TryRebound()
    {
        if(_currentCountRebound <= 0)
        {
            _isReturn = true;
            return false;
        }

        if(_countRebound >= 1)
        {
            _currentCountRebound -= 1;
            return true;
        }

        return false;
    }

    private void Update()
    {

    }
}