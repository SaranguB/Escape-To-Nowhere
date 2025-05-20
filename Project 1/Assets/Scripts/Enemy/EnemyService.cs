using Main;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyService
    {
        private EnemyController enemyController;

        private float spawnTimer;
        private float spawnRate;
        private EnemyPool enemyPool;
        private EnemySO enemySO;
        private BoxCollider enemySpawnArea;
        private List<EnemyController> enemyList = new();

        public EnemyService(EnemySO enemySO, BoxCollider enemySpawnArea)
        {
            this.enemySpawnArea = enemySpawnArea;
            this.enemySO = enemySO;
            this.enemySpawnArea = enemySpawnArea;
            spawnRate = enemySO.spawnRate;
            enemyPool = new EnemyPool();

            ResetSpawnTimer();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.eventService.OnDestroyerToggled.AddListener(OnDestroyerToggled);
        }

        public void UnSubscribeToEvents()
        {
            GameService.Instance.eventService.OnDestroyerToggled.RemoveListener(OnDestroyerToggled);
        }

        public void Update()
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                SpawnEnemy();
                ResetSpawnTimer();
            }
        }

        private void SpawnEnemy()
        {
            EnemyType randomEnemy = GetRandomEnemyType();
            EnemyController enemy = FetchEnemy(randomEnemy);
            enemy.ConfigureEnemy(GetSpawnPosition());
        }

        public Vector3 GetSpawnPosition()
        {
            Bounds bounds = enemySpawnArea.bounds;

            float x = 0f;
            float z = 0f;

            // Check which side the spawn should happen on
            int side = UnityEngine.Random.Range(0, 4);

            switch (side)
            {
                case 0: // Left side of the bounds
                    x = bounds.min.x - enemySO.spawnOffset;
                    z = UnityEngine.Random.Range(bounds.min.z - enemySO.spawnOffset, bounds.max.z + enemySO.spawnOffset);
                    break;
                case 1: // Right side of the bounds
                    x = bounds.max.x + enemySO.spawnOffset;
                    z = UnityEngine.Random.Range(bounds.min.z - enemySO.spawnOffset, bounds.max.z + enemySO.spawnOffset);
                    break;
                case 2: // Top side of the bounds
                    x = UnityEngine.Random.Range(bounds.min.x - enemySO.spawnOffset, bounds.max.x + enemySO.spawnOffset);
                    z = bounds.max.z + enemySO.spawnOffset;
                    break;
                case 3: // Bottom side of the bounds
                    x = UnityEngine.Random.Range(bounds.min.x - enemySO.spawnOffset, bounds.max.x + enemySO.spawnOffset);
                    z = bounds.min.z - enemySO.spawnOffset;
                    break;
            }

            float y = GetTerrainHeightAtPosition(x, z);

            return new Vector3(x, y, z);
        }

        private float GetTerrainHeightAtPosition(float x, float z)
        {
            RaycastHit hit;
            Vector3 rayOrigin = new Vector3(x, enemySO.rayOrigionYValue, z);
            if (Physics.Raycast(rayOrigin, Vector3.down, out hit))
            {
                return hit.point.y;
            }
            return 0f;
        }

        private EnemyController FetchEnemy(EnemyType typeToFetch)
        {
            EnemyData fecthedData = enemySO.enemyData.Find(item => item.enemyType == typeToFetch);

            switch (typeToFetch)
            {
                case EnemyType.Viking:
                    EnemyController enemy = enemyPool.GetEnemy<VikingController>(fecthedData);
                    enemyList.Add(enemy);
                    return enemy;
                default:
                    throw new Exception($"Failed to Create EnemyController for: {typeToFetch}");
            }
        }

        private EnemyType GetRandomEnemyType()
        {
            Array values = Enum.GetValues(typeof(EnemyType));
            return (EnemyType)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        }

        private void ResetSpawnTimer()
          => spawnTimer = spawnRate;

        public void ReturnEnemyToPool(EnemyController enemyToReturn)
            => enemyPool.ReturnItem(enemyToReturn);

        public void OnDestroyerToggled()
        {
            if (enemyList.Count > 0)
            {
                foreach (EnemyController enemy in enemyList)
                {
                    enemy.RemoveEnemy();
                }
            }
            enemyList.Clear();
        }
    }
}
