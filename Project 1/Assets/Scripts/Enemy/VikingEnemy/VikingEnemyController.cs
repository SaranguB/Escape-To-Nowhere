
using UnityEngine;

namespace Enemy
{
    public class VikingEnemyController : EnemyController
    {
        private EnemyData enemyData;
        private EnemyView enemyView;

        public VikingEnemyController(EnemyData enemyData) : base(enemyData) 
        {
            this.enemyData = enemyData;

            enemyView = Object.Instantiate(enemyData.enemyPrefab);
            enemyView.SetController(this);
        }

        public override void ConfigureEnemy(Vector3 spawnPosition)
        {
            enemyView.SetPosition(spawnPosition);
        }
    }
}
