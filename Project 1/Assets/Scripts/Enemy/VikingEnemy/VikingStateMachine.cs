using StateMachine;
using UnityEngine.AI;

namespace Enemy
{
    public class VikingStateMachine : GenericStateMachine<VikingController, EnemyStates>
    {
        public VikingStateMachine(VikingController owner, NavMeshAgent navMeshAgent) : base(owner)
        {
            CreateState(navMeshAgent);
            SetOwner();
        }

        private void CreateState(NavMeshAgent navMeshAgent)
        {
            AddState(EnemyStates.Idle, new IdleState<VikingController>());
            AddState(EnemyStates.Attack, new AttackState<VikingController>(navMeshAgent));
        }
    }
}