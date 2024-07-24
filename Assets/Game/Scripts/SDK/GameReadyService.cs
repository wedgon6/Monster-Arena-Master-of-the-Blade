using Agava.YandexGames;
using UnityEngine;

public class GameReadyService : IGameReadyService
{
    public void GameReady()
    {
#if UNITY_EDITOR
        Debug.Log("GAME READY");
#else
        YandexGamesSdk.GameReady();
        Debug.Log("GAME READY");
#endif
    }
}