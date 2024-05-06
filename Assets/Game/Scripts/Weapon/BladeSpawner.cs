using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class BladeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _weaponPoints;
    [SerializeField] private Blade _bladePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Movment _playerMovment;
    [SerializeField] private Pool _bladePool;

    private float _playerSpeed;
    private Vector3 dir;

    private float _currentTime = 2f;
    private float _time = 3f;

    public bool TryThrowBlade()
    {
        Blade blade;
        Vector3 direction = _shootPoint.transform.position + Vector3.forward*2f;
        
        Debug.Log(direction);

        blade = Instantiate(_bladePrefab, _shootPoint.transform.position, _bladePrefab.transform.rotation);
        blade.GetComponent<Rigidbody>().AddForce(_shootPoint.forward * 4f, ForceMode.VelocityChange);
        //_bladePool.InstantiatePoolObject(blade);
        blade.Initialaze(this);
        return true;
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
                TryThrowBlade();
                _currentTime = _time;
            }
        }

        _currentTime -= Time.deltaTime;
    }

    private void GetBackBlade()
    {
        foreach (var bladeViwe in _weaponPoints)
        {
            if (bladeViwe.gameObject.activeSelf == false)
            {
                bladeViwe.gameObject.SetActive(true);
                return;
            }
        }
    }

    private Vector3 CalculateDirection()
    {
        dir += transform.position.x * GetCameraRight() * 2f;
        dir += transform.position.y * GetCameraForward() * 2f;

        return dir;
    }

    private Vector3 GetCameraRight()
    {
        Vector3 forward = _playerMovment.Camera.transform.right;
        forward.y = 0;

        return forward.normalized;
    }

    private Vector3 GetCameraForward()
    {
        Vector3 right = _playerMovment.Camera.transform.forward;
        right.y = 0;

        return right.normalized;
    }
}