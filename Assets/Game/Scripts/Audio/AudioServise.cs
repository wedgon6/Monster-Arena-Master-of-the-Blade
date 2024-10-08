using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.Audio
{
    public class AudioServise : IAudioServise
    {
        private static bool s_canPlayAudio = true;
        private static bool s_isCloseAds = true;
        private static bool s_isUnMuteAudio = true;

        public bool IsUnMuteAudio { get => s_isUnMuteAudio; set => throw new System.NotImplementedException(); }

        public void ChengeAdsAudio(bool isClose)
        {
            s_isCloseAds = isClose;
        }

        public bool GetAudioModStatus()
        {
            return s_canPlayAudio;
        }

        public void ChengeAudioStatus()
        {
            s_canPlayAudio = !s_canPlayAudio;

            if (s_canPlayAudio == false)
            {
                AudioListener.volume = 0f;
                s_isUnMuteAudio = false;
            }

            if (s_canPlayAudio)
            {
                AudioListener.volume = 1f;
                s_isUnMuteAudio = true;
            }
        }

        public void MuteSound()
        {
            if (s_canPlayAudio == false)
                return;

            AudioListener.volume = 0f;
            s_canPlayAudio = false;
        }

        public void TurnSound()
        {
            if (s_canPlayAudio == true || s_isUnMuteAudio == false)
                return;

            AudioListener.volume = 1f;
            s_canPlayAudio = true;
        }

        public bool CanTurnSound()
        {
            bool canTurn = s_isCloseAds == false || s_isUnMuteAudio == false || s_canPlayAudio == false;

            return !canTurn;
        }
    }
}