using Agava.YandexGames;

public class GameReadyService : IGameReadyService
{
    public void GameReady()
    {
#if !UNITY_EDITOR
        YandexGamesSdk.GameReady();
#endif
    }
}