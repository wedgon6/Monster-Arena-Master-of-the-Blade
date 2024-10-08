using MonsterArenaMasterOfTheBlade.ServicesScripts;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterArenaMasterOfTheBlade.UI
{
    [RequireComponent(typeof(Button))]
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private Image _controlButton;
        [SerializeField] private Sprite _onAudioIcon;
        [SerializeField] private Sprite _offAudioIcon;

        private Button _button;
        private bool _isAudioPlay = true;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ChangeSoundMode);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ChangeSoundMode);
        }

        public void Initialize()
        {
            _isAudioPlay = Services.AudioService.GetAudioModStatus();

            if (_isAudioPlay == true)
            {
                _controlButton.sprite = _onAudioIcon;
            }

            if (_isAudioPlay == true && Services.AudioService.IsUnMuteAudio)
            {
                _controlButton.sprite = _onAudioIcon;
            }

            if (_isAudioPlay == false && Services.AdvertisemintService.IsCloseAds == false)
            {
                _controlButton.sprite = _offAudioIcon;
            }

            if (_isAudioPlay == false && Services.AdvertisemintService.IsCloseAds == true)
            {
                _controlButton.sprite = _onAudioIcon;
            }
        }

        private void ChangeSoundMode()
        {
            Services.AudioService.ChengeAudioStatus();
            _isAudioPlay = Services.AudioService.GetAudioModStatus();

            if (_isAudioPlay == true)
            {
                _controlButton.sprite = _onAudioIcon;
            }

            if (_isAudioPlay == false)
            {
                _controlButton.sprite = _offAudioIcon;
            }
        }
    }
}