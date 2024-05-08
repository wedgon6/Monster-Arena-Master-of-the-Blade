using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BladeViwe : MonoBehaviour
{
    [SerializeField] private Movment _player;
    [SerializeField] private float _insideRadius = 1;

    private int _countBlade;
    private BladeViwePrafab _viwePrafab;
    private List<BladeViwePrafab> _bladeViwePrafabs = new List<BladeViwePrafab>();
    private float _stepSize;
    private float _currentStep;

    public void Initialize(int countBlade, Blade blade)
    {
        _countBlade = countBlade;
        _viwePrafab = blade.BladeViwePrafab;
        _stepSize = 360 / _countBlade;

        for (int i = 0; i < _countBlade; i++)
        {
            var angle = _currentStep * Mathf.Deg2Rad;
            var distance = _insideRadius;
            var x = distance * Mathf.Sin(angle);
            var z = distance * Mathf.Cos(angle);
            var position = _player.transform.position + new Vector3(x, transform.position.y, z);
            _currentStep += _stepSize;

            _bladeViwePrafabs.Add(Instantiate(_viwePrafab, position, _viwePrafab.transform.rotation, transform));
        }
    }

    public bool ThryThrow()
    {
        BladeViwePrafab enebleBlade = _bladeViwePrafabs.FirstOrDefault(p => p.gameObject.activeSelf == true);

        if (enebleBlade == null)
            return false;
        else
        {
            enebleBlade.gameObject.SetActive(false);
            return true;
        }
    }

    public void GetBackBlade()
    {
        BladeViwePrafab enebleBlade = _bladeViwePrafabs.FirstOrDefault(p => p.gameObject.activeSelf == false);

        if (enebleBlade == null)
            return;
        else
            enebleBlade.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        transform.DORotate(new Vector3(0, 360f, 0), 1f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetRelative().SetEase(Ease.Linear);
    }
}