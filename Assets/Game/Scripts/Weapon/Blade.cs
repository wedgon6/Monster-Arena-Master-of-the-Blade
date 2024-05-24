using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blade : PoolObject
{
    [SerializeField] private BladeViwePrafab _bladeViwe;

    private BladeSpawner _bladeSpawner;
    private int _countRebound;
    private int _currentCountRebound;
    private bool _isReturn = false;
    private float _damage = 20f;

    private Vector3 _startPoint;
    private Vector3 _direction;
    private Coroutine _coroutine;
    private Rigidbody _rigidbody;

    public bool IsReturn => _isReturn;
    public BladeSpawner BladeSpawner => _bladeSpawner;
    public Vector3 StartPoint => _startPoint;
    public BladeViwePrafab BladeViwePrafab => _bladeViwe;

    public void Initialaze(BladeSpawner bladeSpawner)
    {
        _bladeSpawner = bladeSpawner;
        _startPoint = _bladeSpawner.transform.position;
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
        transform.DORotate(new Vector3(0, 360f, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }

    private void FixedUpdate()
    {
        if (_isReturn)
        {
            transform.position = Vector3.Lerp(transform.position, _bladeSpawner.transform.position, 7f * Time.fixedDeltaTime);
            _rigidbody.velocity = Vector3.zero;
            _direction = new Vector3(_bladeSpawner.transform.position.x, _bladeSpawner.transform.position.y, _bladeSpawner.transform.position.z).normalized;
            _rigidbody.AddForce(_direction * 5f);
            _direction = Vector3.zero;
        }
    }

    private IEnumerator Throw()
    {
        _isReturn = false;
        float time = 1.5f;
        //_startPoint - transform.position).magnitude <= 5f
        while (time >= 0f)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        CorountineStart(BackToPlayer());
    }

    private IEnumerator BackToPlayer()
    {
        _isReturn = true;

        while (Vector3.Magnitude(transform.position - _bladeSpawner.transform.position) >= 1f)
        {
            yield return null;
        }
       
        ReturObjectPool();
    }

    private void CorountineStart(IEnumerator corontine)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(corontine);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Vector3 direction = (enemy.transform.position - transform.position) * 2;
            enemy.Rigidbody.AddForce(direction, ForceMode.VelocityChange);

            CorountineStart(BackToPlayer());
        }
    }
}