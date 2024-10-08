using Agava.WebUtility;
using MonsterArenaMasterOfTheBlade.ServicesScripts;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.SDK
{
    public class ApplicationFocus : MonoBehaviour
    {
        private void OnEnable()
        {
            Application.focusChanged += OnInBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWed;
        }

        private void OnDisable()
        {
            Application.focusChanged -= OnInBackgroundChangeApp;
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWed;
        }

        private void OnInBackgroundChangeApp(bool inApp)
        {
            MuteAudio(!inApp);
            PauseGame(!inApp);
        }

        private void OnInBackgroundChangeWed(bool isBackground)
        {
            MuteAudio(isBackground);
            PauseGame(isBackground);
        }

        private void MuteAudio(bool value)
        {
            if (!value)
            {
                if (Services.AudioService.CanTurnSound())
                    Services.AudioService.TurnSound();
            }
            else
            {
                Services.AudioService.MuteSound();
            }
        }

        private void PauseGame(bool value)
        {
            if (!value)
            {
                if (Services.GameStopControl.TryChangetGameStop() == true && Services.AdvertisemintService.IsCloseAds == true)
                    Services.GameStopControl.ChangetGameStop(false);
            }
            else
            {
                Services.GameStopControl.ChangetGameStop(true);
            }
        }
    }
}