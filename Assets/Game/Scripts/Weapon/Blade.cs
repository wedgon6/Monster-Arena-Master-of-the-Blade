using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blade : PoolObject
{
    [SerializeField] private BladeStateMashine _stateMashine;

    private BladeSpawner _bladeSpawner;
    private int _countRebound;
    private int _currentCountRebound;
    private bool _isReturn = false;

    private Vector3 _startPoint;
    private Vector3 _direction;
    private Coroutine _coroutine;
    private Rigidbody _rigidbody;

    public bool IsReturn => _isReturn;
    public BladeSpawner BladeSpawner => _bladeSpawner;
    public Vector3 StartPoint => _startPoint;

    public void ResetState() => _stateMashine.ResetStete();

    public void Initialaze(BladeSpawner bladeSpawner)
    {
        _bladeSpawner = bladeSpawner;
        CorountineStart(Throw());
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
            _isReturn = false;
            return true;
        }

        return false;
    }

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        transform.DORotate(new Vector3(0, 360f, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }

    private void FixedUpdate()
    {
        if (_isReturn)
        {
            transform.position = Vector3.Lerp(transform.position, _bladeSpawner.transform.position, 1f * Time.fixedDeltaTime);
            _rigidbody.velocity = Vector3.zero;
            _direction = new Vector3(_bladeSpawner.transform.position.x, 0, _bladeSpawner.transform.position.z);
            _rigidbody.AddForce(_direction * 1f);
            _direction = Vector3.zero;
        }
    }

    private IEnumerator Throw()
    {
        Debug.Log("Throw");
        while(Vector3.Distance(_startPoint,transform.position) < 15f)
        {
            yield return null;
        }

        CorountineStart(BackToPlayer());
    }

    private IEnumerator BackToPlayer()
    {
        Debug.Log("back");
        _isReturn = true;
        while ((int)transform.position.z != (int)_bladeSpawner.transform.position.z)
        {
            //transform.position = Vector3.MoveTowards(transform.position, _bladeSpawner.transform.position, 1f);
            yield return null;
        }

        //ReturObjectPool();
    }

    private void CorountineStart(IEnumerator corontine)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(corontine);
    }
}