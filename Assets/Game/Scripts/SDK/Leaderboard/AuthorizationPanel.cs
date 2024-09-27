using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace MonsterArenaMasterOfTheBlade.SDK
{
    public class AuthorizationPanel : MonoBehaviour
    {
        [SerializeField] private Button _authorizationButton;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Leaderboard _leaderboard;

        private void OnEnable()
        {
            _authorizationButton.onClick.AddListener(OnAuthorization);
            _closeButton.onClick.AddListener(OnClose);
        }

        private void OnDisable()
        {
            _authorizationButton.onClick.RemoveListener(OnAuthorization);
            _closeButton.onClick.RemoveListener(OnClose);
        }

        private void OnAuthorization()
        {
            PlayerAccount.Authorize(OnRequestDataPermission);
        }

        private void OnClose()
        {
            gameObject.SetActive(false);
        }

        private void OnRequestDataPermission()
        {
            if (PlayerAccount.IsAuthorized)
                PlayerAccount.RequestPersonalProfileDataPermission();

            _leaderboard.Fill();
            gameObject.SetActive(false);
        }
    }
}