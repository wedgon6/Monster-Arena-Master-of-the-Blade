using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterArenaMasterOfTheBlade.Audio
{
    public class ButtonAudioSourse : MonoBehaviour
    {
        [SerializeField] private List<Button> _buttons;
        [SerializeField] private List<AudioSource> _clickSounds;

        private int _indexSound = 0;

        private void OnEnable()
        {
            foreach (var button in _buttons)
            {
                if (button != null)
                    button.onClick.AddListener(OnPlayClickSound);
            }
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                if (button != null)
                    button.onClick.RemoveListener(OnPlayClickSound);
            }
        }

        private void OnPlayClickSound()
        {
            _clickSounds[_indexSound].Play();
            _indexSound++;

            if (_indexSound >= _clickSounds.Count)
                _indexSound = 0;
        }
    }
}