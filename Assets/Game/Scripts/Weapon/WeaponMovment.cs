using DG.Tweening;
using System.Collections;
using UnityEngine;

public class WeaponMovment : MonoBehaviour
{
    [SerializeField] private Transform[] _weaponPoints;
    [SerializeField] private Blade _blade;

    private float _speed;

    private void Awake()
    {
        RotateBlades();
    }

    private void RotateBlades()
    {
        transform.DORotate(new Vector3(0, 360f, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }

    public bool TryThrowBlade()
    {
        foreach (var blde in _weaponPoints)
        {
            if(blde.gameObject.activeSelf == true)
            {
                blde.gameObject.SetActive(false);
                return true;
            }
        }

        return false;
    }
}