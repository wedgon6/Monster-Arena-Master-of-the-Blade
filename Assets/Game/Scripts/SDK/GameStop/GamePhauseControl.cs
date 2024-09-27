using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.SDK
{
    public class GamePhauseControl : IGamePhauseControl
    {
        private static bool _canGame = true;

        public void ChangetGameStop(bool value)
        {
            _canGame = value;
            Time.timeScale = value ? 0 : 1;
        }

        public bool TryChangetGameStop()
        {
            return _canGame;
        }
    }
}