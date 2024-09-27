using System;

namespace MonsterArenaMasterOfTheBlade.Characters
{
    [Serializable]
    public class HashAnimationPlayer
    {
        private string _moveAnimation = "Speed";
        private string _throwAnimation = "OnThrow";
        private string _deadAnimation = "IsDead";
        private string _winDanceAnimation = "Win";

        public string MoveAnimation => _moveAnimation;
        public string ThrowAnimation => _throwAnimation;
        public string DeadAnimation => _deadAnimation;
        public string WinDanceAnimation => _winDanceAnimation;
    }
}