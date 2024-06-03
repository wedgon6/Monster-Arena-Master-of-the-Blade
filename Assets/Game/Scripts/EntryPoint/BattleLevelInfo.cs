using UnityEngine;

public class BattleLevelInfo : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner.RestSpawner(0);
    }
}