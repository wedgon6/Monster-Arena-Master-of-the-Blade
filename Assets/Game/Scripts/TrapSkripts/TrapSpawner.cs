using System.Collections.Generic;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.TrapScripts
{
    public class TrapSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _traps;
        [SerializeField] private List<Transform> _spawnPoints;

        private int _equalizationCoefficient = 1;

        public void Initialize(int starsCount, int countCircle)
        {
            int countTrap = starsCount + countCircle + _equalizationCoefficient;
            int currentSpawnPont;
            int trapIndex;

            for (int i = 0; i < countTrap; i++)
            {
                currentSpawnPont = Random.Range(0, _spawnPoints.Count);
                trapIndex = Random.Range(0, _traps.Count);
                GameObject trap = _traps[trapIndex];
                Instantiate(trap, _spawnPoints[currentSpawnPont].position, _spawnPoints[currentSpawnPont].rotation, _spawnPoints[currentSpawnPont]);
                _spawnPoints.RemoveAt(currentSpawnPont);
            }
        }
    }
}