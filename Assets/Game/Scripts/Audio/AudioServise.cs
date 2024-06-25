using UnityEngine;

public class AudioServise : IAudioServise
{
    private static bool _canPlayAudio = true;

    public bool GetAudioModStatus()
    {
        return _canPlayAudio;
    }

    public void ChengeAudioStatus()
    {
        _canPlayAudio = !_canPlayAudio;

        if (_canPlayAudio == false)
            AudioListener.volume = 0f;

        if(_canPlayAudio)
            AudioListener.volume = 1f;
    }
}