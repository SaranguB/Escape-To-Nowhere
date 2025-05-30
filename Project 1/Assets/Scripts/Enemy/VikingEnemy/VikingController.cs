using Main;
using UnityEngine;

namespace Enemy
{
    public class VikingController : EnemyController
    {
        private EnemyView enemyView;
        private VikingStateMachine vikingStateMachine;

        public VikingController(EnemyData enemyData) : base(enemyData)
        {
            enemyView = Object.Instantiate(enemyData.enemyPrefab);
            enemyView.SetController(this);
            CreateStateMachine(enemyData);
            ChangeState(EnemyStates.Idle);
        }

        private void CreateStateMachine(EnemyData enemyData)
            => vikingStateMachine = new VikingStateMachine(this, enemyView.GetNavMeshAgent(), enemyData);

        public override void ChangeState(EnemyStates state)
           => vikingStateMachine.ChangeState(state);

        public override void ConfigureEnemy(Vector3 spawnPosition)
        {
            enemyView.gameObject.SetActive(true);
            enemyView.SetPosition(spawnPosition);
        }

        public override void UpdateStateMachine()
            => vikingStateMachine.Update();

        public override void DestroyEnemy(VFX.VFXType enemyDeathEffect, Vector3 position)
        {
            base.DestroyEnemy(enemyDeathEffect, position);
            enemyView.gameObject.SetActive(false);
            GameService.Instance.enemyService.ReturnEnemyToPool(this);
        }

        public override void RemoveEnemy()
           => enemyView.DestroyEnemy();

    }
}
