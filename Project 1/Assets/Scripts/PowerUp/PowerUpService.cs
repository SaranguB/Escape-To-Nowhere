using Enemy;
using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace PowerUps
{
    public class PowerUpService
    {
        private PowerUpSO powerUpSO;
        private PowerUpPool powerUpPool;

        private bool isSpawning;
        private float spawnTimer;
        private BoxCollider powerUpSpawnArea;

        public PowerUpService(PowerUpSO powerUpSO)
        {
            this.powerUpSO = powerUpSO;
            powerUpPool = new PowerUpPool();
            spawnTimer = this.powerUpSO.spawnRate;
            isSpawning = true;
        }

        public void Update()
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                SpawnPowerUps();
                ResetSpawnTimer();
            }
        }

        private void ResetSpawnTimer()
         => spawnTimer = powerUpSO.spawnRate;

        private void SpawnPowerUps()
        {
            if (isSpawning)
            {
              
                PowerUpType randomPowerUp = (PowerUpType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(PowerUpType)).Length);
              
                PowerUpController powerUp = FetchPowerUp(randomPowerUp);

                powerUp.Configure(CalculateRandomSpawnPosition());
            }
        }

        private PowerUpController FetchPowerUp(PowerUpType typeToFetch)
        {
            PowerUpData fetchedData = powerUpSO.powerUpData.Find(item => item.powerUpType == typeToFetch);

            switch (typeToFetch)
            {
                case PowerUpType.SpeedBooster:
                    return (PowerUpController)powerUpPool.GetPowerUp<SpeedBooster>(fetchedData);
                default:
                    throw new Exception($"Failed to Create PowerUpController for: {typeToFetch}");
            }
        }

        public Vector3 GetSpawnPosition()
        {
            Bounds bounds = powerUpSpawnArea.bounds;

            float x = 0f;
            float z = 0f;

            // Check which side the spawn should happen on
            int side = UnityEngine.Random.Range(0, 4);

            switch (side)
            {
                case 0: // Left side of the bounds
                    x = bounds.min.x - powerUpSO.spawnOffset;
                    z = UnityEngine.Random.Range(bounds.min.z - powerUpSO.spawnOffset, bounds.max.z + powerUpSO.spawnOffset);
                    break;
                case 1: // Right side of the bounds
                    x = bounds.max.x + powerUpSO.spawnOffset;
                    z = UnityEngine.Random.Range(bounds.min.z - powerUpSO.spawnOffset, bounds.max.z + powerUpSO.spawnOffset);
                    break;
                case 2: // Top side of the bounds
                    x = UnityEngine.Random.Range(bounds.min.x - powerUpSO.spawnOffset, bounds.max.x + powerUpSO.spawnOffset);
                    z = bounds.max.z + powerUpSO.spawnOffset;
                    break;
                case 3: // Bottom side of the bounds
                    x = UnityEngine.Random.Range(bounds.min.x - powerUpSO.spawnOffset, bounds.max.x + powerUpSO.spawnOffset);
                    z = bounds.min.z - powerUpSO.spawnOffset;
                    break;
            }

            float y = GetTerrainHeightAtPosition(x, z);

            return new Vector3(x, y, z);
        }

        private float GetTerrainHeightAtPosition(float x, float z)
        {
            RaycastHit hit;
            Vector3 rayOrigin = new Vector3(x, powerUpSO.rayOrigionYValue, z);
            if (Physics.Raycast(rayOrigin, Vector3.down, out hit))
            {
                return hit.point.y;
            }
            return 0f;
        }
    }
}
