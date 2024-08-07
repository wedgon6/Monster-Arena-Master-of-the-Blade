public interface IAudioServise 
{
    public bool GetAudioModStatus();
    public void ChengeAudioStatus();
    public void MuteSound();
    public void TurnSound();
    public bool TryTurnSound();
    public void ChengeAdsAudio(bool isClose);
}