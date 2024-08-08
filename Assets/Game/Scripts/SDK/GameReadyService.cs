using Agava.YandexGames;
using UnityEngine;

public class GameReadyService : IGameReadyService
{
    public void GameReady()
    {
#if !UNITY_EDITOR
        YandexGamesSdk.GameReady();
        Debug.Log("GAME READY");
#endif
    }
}