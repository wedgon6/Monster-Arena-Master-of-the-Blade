using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Transform _lootAt;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Enemy _enemy;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _enemy.ChengetHealt += OnChengedBarValue;
    }

    private void OnDisable()
    {
        _enemy.ChengetHealt -= OnChengedBarValue;
    }

    private void Update()
    {
        transform.LookAt(_camera.transform);
    }

    private void OnChengedBarValue()
    {

    }
}