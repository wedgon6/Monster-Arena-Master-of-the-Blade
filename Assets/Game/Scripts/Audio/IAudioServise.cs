namespace MonsterArenaMasterOfTheBlade.Audio
{
    public interface IAudioServise
    {
        public bool IsUnMuteAudio { get; set; }
        public bool GetAudioModStatus();
        public void ChengeAudioStatus();
        public void MuteSound();
        public void TurnSound();
        public bool CanTurnSound();
        public void ChengeAdsAudio(bool isClose);
    }
}