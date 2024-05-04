using UnityEngine;

[RequireComponent(typeof(Blade))]
public class BladeState : State
{
    protected Blade _blade;
    protected BladeSpawner _bladeSpawner;

    public Blade Blade => _blade;

    private void Awake()
    {
        enabled = false;
    }

    protected override void OnEnter()
    {
        _blade = GetComponent<Blade>();
        _bladeSpawner = _blade.BladeSpawner;
    }
}