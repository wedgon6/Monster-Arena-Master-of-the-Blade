using DG.Tweening;
using UnityEngine;

public class WeaponMovment : MonoBehaviour
{
    private void Awake()
    {
        RotateBlades();
    }

    private void RotateBlades()
    {
        transform.DORotate(new Vector3(0, 360f, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }
}