using UnityEngine;
using UnityEngine.UI;

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

    private void ChangeSoundMode()
    {
        Services.AudioServise.ChengeAudioStatus();
        _isAudioPlay = Services.AudioServise.GetAudioModStatus();

        if (_isAudioPlay == true)
        {
            AudioListener.volume = 1f;
            _controlButton.sprite = _onAudioIcon;
        }

        if (_isAudioPlay == false)
        {
            AudioListener.volume = 0f;
            _controlButton.sprite = _offAudioIcon;
        }
    }
}