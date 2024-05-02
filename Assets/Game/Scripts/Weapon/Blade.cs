using DG.Tweening;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blade : MonoBehaviour
{
    private Vector3 _endPoint;
    private Tweener _tween;
    private Tweener _start;

    public void Attac(Vector3 targetPoint)
    {

        transform.DORotate(new Vector3(0, 360f, 0), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
        Vector3 duration = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);
        _endPoint = targetPoint;
        _start = transform.DOMove(duration, 3f).SetEase(Ease.Linear);
    }

    private void Update()
    {

    }

    private IEnumerator StartThrow()
    {
        yield return null;
    }

    private IEnumerator ReturnThrow()
    {
       
        yield return null;
    }
}