using StateMachine;
using UnityEngine;

namespace Enemy
{
    public class IdleState<T> : IState<T> where T : EnemyController
    {
        public T owner { get; set; }

        public IdleState()
        {
            
        }

        public void OnStateEnter()
        {
           
        }

        public void UpdateState()
        {
        }

        public void FixedUpdateState()
        {
        }

        public void OnStateExit()
        {
        }
    }
}