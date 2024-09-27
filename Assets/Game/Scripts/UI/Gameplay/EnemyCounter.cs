using MonsterArenaMasterOfTheBlade.Characters;
using System;
using TMPro;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.UI
{
    public class EnemyCounter : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private TMP_Text _countText;

        private int _currentCountEnemy;

        public event Action AllEnemyDied;

        private void Start()
        {
            _spawner.EnemyDead += SetEnemyCount;
            _currentCountEnemy = _spawner.GetEnemyCount();
            _countText.text = _currentCountEnemy.ToString();
        }

        private void OnDisable()
        {
            _spawner.EnemyDead -= SetEnemyCount;
        }

        private void SetEnemyCount()
        {
            if (_currentCountEnemy <= 0)
                return;

            _currentCountEnemy--;
            _countText.text = _currentCountEnemy.ToString();

            if (_currentCountEnemy <= 0)
                AllEnemyDied?.Invoke();
        }
    }
}