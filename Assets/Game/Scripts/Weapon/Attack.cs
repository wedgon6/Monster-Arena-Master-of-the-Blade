using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Blade _bladePrefab;
    [SerializeField] private WeaponMovment _weaponMovment;
    [SerializeField] private Transform _shootPoint;

    private float _speed = 20f;

    private void Start()
    {
        Thorow();
    }

    private void Thorow()
    {
        if (_weaponMovment.TryThrowBlade())
        {
            Blade blade = Instantiate(_bladePrefab, _shootPoint.transform.position, _bladePrefab.transform.rotation);
            blade.Attac(_shootPoint.position);
        }
    }
}