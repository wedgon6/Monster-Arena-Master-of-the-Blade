using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _traps;
    [SerializeField] private List<Transform> _spawnPoints;

    public void Initialize(int starsCount)
    {
        if (starsCount == 0)
            starsCount = 1;

        int currentSpawnPont;
        int trapIndex;

        for (int i = 0; i < starsCount; i++)
        {
            currentSpawnPont = Random.Range(0, _spawnPoints.Count);
            trapIndex = Random.Range(0, _traps.Count);
            GameObject trap = _traps[trapIndex];
            Instantiate(trap, _spawnPoints[currentSpawnPont].position, _spawnPoints[currentSpawnPont].rotation, _spawnPoints[currentSpawnPont]);
        }
    }
}