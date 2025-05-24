using StateMachine;
using UnityEngine.AI;

namespace Enemy
{
    public class VikingStateMachine : GenericStateMachine<VikingController, EnemyStates>
    {
        public VikingStateMachine(VikingController owner, NavMeshAgent navMeshAgent, EnemyData enemyData) : base(owner)
        {
            CreateState(navMeshAgent, enemyData);
            SetOwner();
        }

        private void CreateState(NavMeshAgent navMeshAgent, EnemyData enemyData)
        {
            AddState(EnemyStates.Idle, new IdleState<VikingController>());
            AddState(EnemyStates.Attack, new AttackState<VikingController>(navMeshAgent, enemyData));
        }
    }
}