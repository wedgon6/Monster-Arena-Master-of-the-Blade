using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private BladeSpawner _bladeSpawner;
    [SerializeField] private Movment _movment;
    
    private float _maxHealth = 1000;
    private float _health;
    private int _earnedScore = 0;

    private Gold _gold = new Gold(0);
    private Daimond _daimond = new Daimond(0);
    private GameInfo _gameInfo;
    private bool _isMobile;

    public PlayerWallet PlayerWallet => _wallet;
    public int EarnedScore => _earnedScore;

    public event Action<float, float> ChangeHealth;
    public event Action<float> TakedDamage;
    public event Action<Transform> Died;
    public event Action Wined;
    public event Action Resurred;

    public void Initialize(bool isMoving)
    {
        PlayerStandartParametrs standartParametrs = new PlayerStandartParametrs();

        _isMobile = isMoving;
        _maxHealth = standartParametrs.StartHealth;
        _health = _maxHealth;
        ChangeHealth?.Invoke(_health, _maxHealth);
        _movment.Initialize(standartParametrs.StartMoveSpeed, _isMobile);
        _bladeSpawner.Initialize(0, standartParametrs.StartDamage, standartParametrs.StartRangeThrow, standartParametrs.StartMoveSpeed);
    }

    public void Initialize(GameInfo gameInfo, bool isMoving)
    {
        _gameInfo = gameInfo;
        _isMobile = isMoving;
        _maxHealth = _gameInfo.MaxPlayerHealth;
        _health = _maxHealth;
        ChangeHealth?.Invoke(_health, _maxHealth);

        _movment.Initialize(_gameInfo.PlayerMoveSpeed, _isMobile);
        _bladeSpawner.Initialize(_gameInfo.CurrentBladeIndex, _gameInfo.Damage, _gameInfo.RangeThrow, _gameInfo.PlayerMoveSpeed);
    }

    public void VictoryDance()
    {
        Wined?.Invoke();
        _movment.Initialize(0, _isMobile);
        _bladeSpawner.TurnOffActive();
    }

    public void AddScore() => _earnedScore++;

    public float GetCurrentHealth() => _health;

    public float GetMaxHealth() => _maxHealth;

    public void Resurrect()
    {
        _health = _maxHealth;
        _movment.Initialize(_gameInfo.PlayerMoveSpeed, _isMobile);
        ChangeHealth?.Invoke(_health, _maxHealth);
        Resurred?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        if (_health <= 0)
            return;

        _health -= damage;
        TakedDamage?.Invoke(damage);
        ChangeHealth?.Invoke(_health, _maxHealth);

        if (_health <= 0)
        {
            _health = 0;
            LoseGame();
        }
    }

    private void Awake()
    {
        _wallet.Initialize(_gold.Value, _daimond.Value);
    }

    private void LoseGame()
    {
        Died?.Invoke(transform);
        _movment.Initialize(0, _isMobile);
        _bladeSpawner.TurnOffActive();
    }
}