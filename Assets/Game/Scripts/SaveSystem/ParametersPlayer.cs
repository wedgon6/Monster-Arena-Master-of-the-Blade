using System;
using UnityEngine;

public class ParametersPlayer : MonoBehaviour
{
    private const float StandartMaxHealth = 100f;
    private const float StandartMoveSpeed = 1f;
    private const float StandartDamage = 20f;
    private const float StandartRangeThrow = 3f;

    [SerializeField] private float _healthStep = 20f;
    [SerializeField] private float _moveSpeedStep = 0.2f;
    [SerializeField] private float _damageStep = 5f;
    [SerializeField] private float _rangeThrowStep = 0.5f;

    private float _maxPlayerHealth;
    private float _playerMoveSpeed;
    private float _damage;
    private float _rangeThrow;

    public event Action SavedData;

    public float MaxPlayerHealth => _maxPlayerHealth;
    public float PlayerMoveSpeed => _playerMoveSpeed;
    public float Damage => _damage;
    public float RangeThrow => _rangeThrow;

    public void Initialize()
    {
        _maxPlayerHealth = StandartMaxHealth;
        _playerMoveSpeed = StandartMoveSpeed;
        _damage = StandartDamage;
        _rangeThrow = StandartRangeThrow;
        Debug.Log(_playerMoveSpeed);
        SavedData?.Invoke();
    }

    public void Initialize(GameInfo data)
    {
        _maxPlayerHealth = data.MaxPlayerHealth;
        _playerMoveSpeed = data.PlayerMoveSpeed;
        _damage = data.Damage;
        _rangeThrow = data.RangeThrow;
        Debug.Log(_playerMoveSpeed);
        SavedData?.Invoke();
    }

    public void AddMaxHealth()
    {
        _maxPlayerHealth += _healthStep;
        SavedData?.Invoke();
    }

    public void AddMoveSpeed()
    {
        _playerMoveSpeed += _moveSpeedStep;
        SavedData?.Invoke();
    }

    public void AddDamage()
    {
        _damage = _damageStep;
        SavedData?.Invoke();
    }

    public void AddRangeThrow()
    {
        _rangeThrow = _rangeThrowStep;
        SavedData?.Invoke();
    }
}