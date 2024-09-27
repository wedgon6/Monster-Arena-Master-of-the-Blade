using MonsterArenaMasterOfTheBlade.Characters;
using MonsterArenaMasterOfTheBlade.Weapon;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.Audio
{
    public class BattleAudioSourse : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private BladeSpawner _bladeSpawner;
        [SerializeField] private List<AudioSource> _enemyDeadSounds;
        [SerializeField] private List<AudioSource> _throwBladeSounds;

        private int _indexEnemyDeadSound;
        private int _indexThrowBladeSound;

        private void OnEnable()
        {
            _enemySpawner.EnemyDead += OnPlayEnemyDeadSound;
            _bladeSpawner.ThrowingBlade += OnPlayBladeThrowSound;
        }

        private void OnDisable()
        {
            _enemySpawner.EnemyDead -= OnPlayEnemyDeadSound;
            _bladeSpawner.ThrowingBlade -= OnPlayBladeThrowSound;
        }

        private void OnPlayBladeThrowSound()
        {
            _throwBladeSounds[_indexThrowBladeSound].Play();
            _indexThrowBladeSound++;

            if (_indexThrowBladeSound >= _throwBladeSounds.Count)
                _indexThrowBladeSound = 0;
        }

        private void OnPlayEnemyDeadSound()
        {
            _enemyDeadSounds[_indexEnemyDeadSound].Play();
            _indexEnemyDeadSound++;

            if (_indexEnemyDeadSound >= _enemyDeadSounds.Count)
                _indexEnemyDeadSound = 0;
        }
    }
}