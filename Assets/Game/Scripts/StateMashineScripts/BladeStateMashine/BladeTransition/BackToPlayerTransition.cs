using UnityEngine;

[RequireComponent(typeof(Blade))]
public class BackToPlayerTransition : Transition
{
    private Blade _blade;

    private void Start()
    {
        _blade = GetComponent<Blade>();
    }

    private void Update()
    {
        if(_blade.IsReturn)
            NeedTransit = true;
    }
}