using StateMachine;
using UnityEngine;
using UnityEngine.AI;


namespace Enemy
{
    public class AttackState<T> : IState<T> where T : EnemyController
    {
        public T owner { get; set; }

        private NavMeshAgent navMeshAgent;
        private EnemyData enemyData;
        public AttackState(NavMeshAgent navMeshAgent, EnemyData enemyData)
        {
            this.enemyData = enemyData;
            this.navMeshAgent = navMeshAgent;
        }

        public void OnStateEnter()
        {
            navMeshAgent.speed = enemyData.speed;
        }

        public void UpdateState()
        {
            if (owner.GetGameState() == GameState.Gameplay)
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