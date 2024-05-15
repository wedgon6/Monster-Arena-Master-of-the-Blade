using Agava.YandexGames;
using UnityEngine;

public class LeaderBoardButton : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private AuthorizationPanel _authorizationPanel;

    public void OpenLeaderboardView()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OpenLeaderboard();
#endif
    }

    private void OpenLeaderboard()
    {
        if (PlayerAccount.IsAuthorized)
        {
            PlayerAccount.RequestPersonalProfileDataPermission();
            _leaderboardPanel.SetActive(true);
            _leaderboard.Fill();
        }

        if (PlayerAccount.IsAuthorized == false)
            _authorizationPanel.gameObject.SetActive(true);
    }
}