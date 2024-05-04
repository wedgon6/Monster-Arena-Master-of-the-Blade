using DG.Tweening;
using UnityEngine;

public class BladeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _weaponPoints;
    [SerializeField] private Blade _bladePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Movment _playerMovment;

    private float _playerSpeed;

    private void Awake()
    {
        RotateBlades();
    }

    private void RotateBlades()
    {
        transform.DORotate(new Vector3(0, 360f, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }

    private void Update()
    {
        _playerSpeed = _playerMovment.PlayerRigidbody.velocity.magnitude / _playerMovment.MaxMoveSpeed;

        if (_playerSpeed < 0.5f)
            TryThrowBlade();
    }

    public bool TryThrowBlade()
    {
        foreach (var bladeViwe in _weaponPoints)
        {
            if(bladeViwe.gameObject.activeSelf == true)
            {
                bladeViwe.gameObject.SetActive(false);
                Blade blade = Instantiate(_bladePrefab, _shootPoint.transform.localPosition, _bladePrefab.transform.rotation);
                blade.Initialaze(_shootPoint.position,this);
                return true;
            }
        }

        return false;
    }
}