using Agava.YandexGames;
using UnityEngine;

public class LeaderBoardButton : MonoBehaviour
{
    [SerializeField] private Leaderboard _leaderboard;
    [SerializeField] private AuthorizationPanel _authorizationPanel;

    private GameObject _leaderboardPanel;

    public void Initialize(GameObject panel)
    {
        _leaderboardPanel = panel;
    }

    public void OpenLeaderboardView()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OpenLeaderboard();
#else
        _leaderboardPanel.SetActive(true);
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