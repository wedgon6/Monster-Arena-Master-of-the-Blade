using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private TMP_Text _countText;

    private void OnEnable()
    {
        _spawner.SetedWaves += SetEnemyCount;
    }

    private void OnDisable()
    {
        _spawner.SetedWaves -= SetEnemyCount;
    }

    private void SetEnemyCount(int waveLengh, int countWave)
    {
        int countEnemy = waveLengh * countWave;
        _countText.text = countEnemy.ToString();
    }
}