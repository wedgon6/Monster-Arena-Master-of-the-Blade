using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IDamageable))]
public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private TMP_Text _damagePopupText;
    [SerializeField] private GameObject _objectHelth;

    private IDamageable _helth;
    //private Player _player;

    #region MonoBehaviour

    private void OnValidate()
    {
        if( _objectHelth.TryGetComponent(out IDamageable health) == false)
            _objectHelth = null;
    }

    #endregion

    private void Start()
    {
        _helth = GetComponent<IDamageable>();

        //if( TryGetComponent<Player>(out Player player))
        //{
        //    _player = player;

        //}
    }

    private void OnEnable()
    {
        _helth = GetComponent<IDamageable>();
        _helth.ChangeHealth += OnChangeHealthValue;
        _helth.TakedDamage += OnTakeDamage;
        OnChangeHealthValue(_helth.GetCurrentHealth(),_helth.GetMaxHealth());
    }

    private void OnDisable()
    {
        _helth.ChangeHealth -= OnChangeHealthValue;
        _helth.TakedDamage -= OnTakeDamage;
    }
    
    private void OnChangeHealthValue(float currentValue, float totalValue)
    {
        float amount = currentValue / (float)totalValue;
        _bar.value = amount;
    }

    private void OnTakeDamage(float damage)
    {
        _damagePopupText.alpha = 255f;
        _damagePopupText.text = damage.ToString();
        _damagePopupText.DOFade(0f, 1.5f).SetEase(Ease.Linear);
    }
}