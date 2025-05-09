using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        private EnemyData dataToUse;
        private EnemyView enemyView;

        public EnemyController(EnemyData enemyData)
        {
            this.dataToUse = enemyData;
        }

        public virtual void ConfigureEnemy(Vector3 spawnPosition)
        {
           
        }
    }
}
