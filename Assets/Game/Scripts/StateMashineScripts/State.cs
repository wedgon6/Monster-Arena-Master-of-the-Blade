using System.Collections.Generic;
using UnityEngine;

namespace MonsterArenaMasterOfTheBlade.StateMashineScripts
{
    public class State : MonoBehaviour
    {
        [SerializeField] protected List<Transition> _transitions;

        public virtual void Enter()
        {
            if (enabled == false)
            {
                enabled = true;
                OnEnter();

                foreach (var transition in _transitions)
                {
                    transition.enabled = true;
                }
            }
        }

        public virtual void Exit()
        {
            if (enabled == true)
            {
                foreach (var transition in _transitions)
                {
                    transition.enabled = false;
                }

                enabled = false;
            }
        }

        public State GetNextState()
        {
            foreach (var transition in _transitions)
            {
                if (transition.NeedTransit)
                    return transition.TargetState;
            }

            return null;
        }

        protected virtual void OnEnter() { }

        private void Awake()
        {
            enabled = false;
        }
    }
}