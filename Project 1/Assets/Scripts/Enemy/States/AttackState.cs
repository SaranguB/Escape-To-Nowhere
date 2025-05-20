using StateMachine;
using UnityEngine;
using UnityEngine.AI;


namespace Enemy
{
    public class AttackState<T> : IState<T> where T : EnemyController
    {
        public T owner { get; set; }

        private NavMeshAgent navMeshAgent;

        public AttackState(NavMeshAgent navMeshAgent)
        {
            this.navMeshAgent = navMeshAgent;
        }

        public void OnStateEnter()
        {
        }

        public void UpdateState()
        {
            navMeshAgent.SetDestination(owner.GetPlayerPosition());
        }

        public void FixedUpdateState()
        {
        }

        public void OnStateExit()
        {

        }
    }
}