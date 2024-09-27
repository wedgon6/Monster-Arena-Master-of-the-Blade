namespace MonsterArenaMasterOfTheBlade.SDK
{
    public interface IGamePhauseControl
    {
        public void ChangetGameStop(bool value);
        public bool TryChangetGameStop();
    }
}