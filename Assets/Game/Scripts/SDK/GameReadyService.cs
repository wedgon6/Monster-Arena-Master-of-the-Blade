using Agava.YandexGames;

namespace MonsterArenaMasterOfTheBlade.SDK
{
    public class GameReadyService : IGameReadyService
    {
        public void GameReady()
        {
#if !UNITY_EDITOR
        YandexGamesSdk.GameReady();
#endif
        }
    }
}