using System;
using System.Collections.Generic;
using UnityEngine;

public class BladeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _weaponPoints;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Movment _playerMovment;
    [SerializeField] private Pool _bladePool;
    [SerializeField] private BladeViwe _bladeViwe;
    [SerializeField] private List<Blade> _blades;

    private Blade _bladePrefab;
    private float _playerSpeed;
    private bool _isActive = false;
    private float _currentTime = 0f;
    private float _time = 1f;
    private float _rangeThrow;
    private float _damage;

    public event Action ThrowingBlade;

    public void Initialize(int indexBlade, float damage, float rangeThrow)
    {
        _bladePrefab = _blades[indexBlade];
        Debug.Log($"index blade in battle {indexBlade}");

        _damage = damage;
        _rangeThrow = rangeThrow;
        _bladeViwe.Initialize(3, _bladePrefab);
    }

    public void TurnOffActive()
    {
        _isActive = false;
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

        if (_isActive)
        {
            if (_playerSpeed <= 0.1f)
            {
                if (_currentTime <= 0f)
                {
                    ThrowBlade();
                    _currentTime = _time;
                }
            }
        }

        if (_playerSpeed > 0.5f)
            _isActive = true;

        _currentTime -= Time.deltaTime;
    }

    private void GetBackBlade()
    {
        _bladeViwe.GetBackBlade();
    }

    private void ThrowBlade()
    {
        if (_bladeViwe.ThryThrow() == false)
        {
            return;
        }
        else
        {
            Blade blade;
            Vector3 direction = _shootPoint.transform.position + Vector3.forward * 2f;

            if (_bladePool.TryPoolObject(out PoolObject pollBlade))
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

            blade.Initialaze(this, _damage);
            blade.GetComponent<Rigidbody>().AddForce(_shootPoint.forward * _rangeThrow, ForceMode.Impulse);
            ThrowingBlade?.Invoke();
        }
    }
}