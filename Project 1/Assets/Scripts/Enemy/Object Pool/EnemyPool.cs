using Enemy;
using ObjectPool;
using System;

namespace Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyData dataToUse;

        public EnemyController GetEnemy<T>(EnemyData enemyData) where T : EnemyController
        {
            dataToUse = enemyData;
            return GetItem<T>();
        }

        protected override EnemyController CreateItem<T>()
        {
            if(typeof(T) == typeof(VikingEnemyController))
                return new VikingEnemyController(dataToUse);
            else
                throw new NotSupportedException($"Power-up type '{typeof(T)}' is not supported.");
        }
    }
}
