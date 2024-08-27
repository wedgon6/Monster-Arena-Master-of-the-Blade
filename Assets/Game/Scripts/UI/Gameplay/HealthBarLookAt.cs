using UnityEngine;

public class HealthBarLookAt : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    //private void FixedUpdate()
    //{
    //    transform.LookAt(_camera.transform);
    //}
    private void Update()
    {
        transform.LookAt(_camera.transform);
    }
}