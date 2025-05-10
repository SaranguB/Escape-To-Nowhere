using StateMachine;
using UnityEngine;


namespace Enemy
{
    public class DeadState<T> : IState<T> where T : EnemyController
    {
        public T owner { get; set; }

        public DeadState()
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

        private void CheckPlayerAttackRange()
        {

        }

        private void AttackPlayerBetweenDelays()
        {

        }

        private void Attack()
        {

        }

        public void OnStateExit()
        {

        }
    }
}