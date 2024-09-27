using System.Collections.Generic;

namespace MonsterArenaMasterOfTheBlade.Characters
{
    [System.Serializable]
    public class EnemyWave
    {
        private List<Enemy> _template;
        private int _currentIndex = -1;

        public EnemyWave(List<Enemy> template)
        {
            _template = template;
        }

        public List<Enemy> Template => _template;

        public Enemy GetNextEnemy()
        {
            if (_template == null)
                return null;

            _currentIndex++;

            if (_currentIndex > _template.Count - 1)
                return null;

            return _template[_currentIndex];
        }
    }
}