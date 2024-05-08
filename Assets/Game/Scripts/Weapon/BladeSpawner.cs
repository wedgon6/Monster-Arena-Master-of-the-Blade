using System;
using UnityEngine;

public class BladeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _weaponPoints;
    [SerializeField] private Blade _bladePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Movment _playerMovment;
    [SerializeField] private Pool _bladePool;
    [SerializeField] private BladeViwe _bladeViwe;

    private float _playerSpeed;

    private float _currentTime = 2f;
    private float _time = 3f;

    public event Action ThrowingBlade;

    public void ThrowBlade()
    {
        if (_bladeViwe.ThryThrow() == false)
            return;
        else
        {
            Blade blade;
            Vector3 direction = _shootPoint.transform.position + Vector3.forward * 2f;

            if(_bladePool.TryPoolObject(out PoolObject pollBlade))
            {
                blade = pollBlade as Blade;
                blade.transform.position = _shootPoint.transform.position;
                blade.transform.rotation = _bladePrefab.transform.rotation;
                blade.gameObject.SetActive(true);
            }
            else
            {
                blade = Instantiate(_bladePrefab, _shootPoint.transform.position, _bladePrefab.transform.rotation);
                _bladePool.InstantiatePoolObject(blade);
            }
            
            blade.Initialaze(this);
            blade.GetComponent<Rigidbody>().AddForce(_shootPoint.forward * 5f, ForceMode.VelocityChange);
            ThrowingBlade?.Invoke();
        }
    }

    private void Start()
    {
        _bladeViwe.Initialize(3, _bladePrefab);
    }

    private void OnEnable()
    {
        _bladePool.GetPoolObject += GetBackBlade;
    }

    private void OnDisable()
    {
        _bladePool.GetPoolObject -= GetBackBlade;
    }

    private void Update()
    {
        _playerSpeed = _playerMovment.PlayerRigidbody.velocity.magnitude / _playerMovment.MaxMoveSpeed;

        if (_playerSpeed < 0.5f)
        {
            if(_currentTime <= 0f)
            {
                ThrowBlade();
                _currentTime = _time;
            }
        }

        _currentTime -= Time.deltaTime;
    }

    private void GetBackBlade()
    {
        _bladeViwe.GetBackBlade();
    }
}