using Agava.YandexGames;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";
    private const string AnonymousRu = "Àíîíèì";
    private const string AnonymousEn = "Anonymous";
    private const string AnonymousTr = "Anonim";
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private CanvasManager _canvasManager;

    private ViewLeaderboard _leaderboardView;
    private List<DataPlayer> _leaderboardPlayers = new List<DataPlayer>();
    private string AnonymousName;

    private void Awake()
    {
        if (Agava.WebUtility.Device.IsMobile)
            _leaderboardView = _canvasManager.ModileCanvas.LeaderboardView;
        else
            _leaderboardView = _canvasManager.DekstopCanvas.LeaderboardView;

#if UNITY_WEBGL && !UNITY_EDITOR
        string languageCode = YandexGamesSdk.Environment.i18n.lang;

        switch (languageCode)
        {
            case RussianCode:
                AnonymousName = AnonymousRu;
                break;
            case EnglishCode:
                AnonymousName = AnonymousEn;
                break;
            case TurkishCode:
                AnonymousName = AnonymousTr;
                break;
            default:
                AnonymousName = AnonymousEn;
                break;
        }
#endif
    }

    public void SetPlayer(int score)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (PlayerAccount.IsAuthorized == false) 
            return;

        Agava.YandexGames.Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if(result == null)
                Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);

            if (result.score < score)
                Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, score);
        });
#endif
    }

    public void Fill()
    {
        _leaderboardPlayers.Clear();

        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, result =>
        {
            foreach (var entry in result.entries)
            {
                var name = entry.player.publicName;
                var rank = entry.rank;
                var score = entry.score;

                if (string.IsNullOrEmpty(name))
                    name = AnonymousName;

                _leaderboardPlayers.Add(new DataPlayer(name, rank, score));
            }

            _leaderboardView.ConstructLeaderboard(_leaderboardPlayers);
        });
    }
}