namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    public class EnemyStateMachine : StateMashine
    {
        private void Start()
        {
            EnterState(_firstState);
        }

        private void Update()
        {
            UpdateStateStatus();
        }

        public void ResetStete()
        {
            EnterState(_firstState);
        }
    }
}