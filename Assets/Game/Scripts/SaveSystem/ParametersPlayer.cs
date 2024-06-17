using System;
using UnityEngine;

public class ParametersPlayer : MonoBehaviour
{
    private const float StandartMaxHealth = 100f;
    private const float StandartMoveSpeed = 1f;
    private const float StandartDamage = 20f;
    private const float StandartRangeThrow = 3f;

    private float _maxPlayerHealth;
    private float _playerMoveSpeed;
    private float _damage;
    private float _rangeThrow;

    public event Action SavedData;

    public float MaxPlayerHealth => _maxPlayerHealth;
    public float PlayerMoveSpeed => _playerMoveSpeed;
    public float Damage => _damage;
    public float RangeThrow => _rangeThrow;

    public void AddMaxHealth()
    {
        SavedData?.Invoke();
    }

    public void AddMoveSpeed()
    {
        SavedData?.Invoke();
    }

    public void AddDamage()
    {
        SavedData?.Invoke();
    }

    public void AddRangeThrow()
    {
        SavedData?.Invoke();
    }
}