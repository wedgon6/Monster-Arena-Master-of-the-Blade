using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.Audio
{
    public class AudioServise : IAudioServise
    {
        private static bool _canPlayAudio = true;
        private static bool _isCloseAds = true;
        private static bool _isUnMuteAudio = true;

        public void ChengeAdsAudio(bool isClose)
        {
            _isCloseAds = isClose;
        }

        public bool GetAudioModStatus()
        {
            return _canPlayAudio;
        }

        public void ChengeAudioStatus()
        {
            _canPlayAudio = !_canPlayAudio;

            if (_canPlayAudio == false)
            {
                AudioListener.volume = 0f;
                _isUnMuteAudio = false;
            }

            if (_canPlayAudio)
            {
                AudioListener.volume = 1f;
                _isUnMuteAudio = true;
            }
        }

        public void MuteSound()
        {
            if (_canPlayAudio == false)
                return;

            AudioListener.volume = 0f;
            _canPlayAudio = false;
        }

        public void TurnSound()
        {
            if (_canPlayAudio == true || _isUnMuteAudio == false)
                return;

            AudioListener.volume = 1f;
            _canPlayAudio = true;
        }

        public bool TryTurnSound()
        {
            if (_isCloseAds == false || _isUnMuteAudio == false || _canPlayAudio == false)
                return false;
            else
                return true;
        }
    }
}