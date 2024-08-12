using System;

[Serializable]
public class PlayerStandartParametrs
{
    private const float StandartMaxHealth = 100f;
    private const float StandartMoveSpeed = 1f;
    private const float StandartDamage = 20f;
    private const float StandartRangeThrow = 3f;
    private const int StandartScore = 0;

    public float StartHealth => StandartMaxHealth;
    public float StartMoveSpeed => StandartMoveSpeed;
    public float StartDamage => StandartDamage;
    public float StartRangeThrow => StandartRangeThrow;
    public float StartScore=> StandartScore;
}