using Enemy;
using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerUps
{
    public class PowerUpService
    {
        private PowerUpSO powerUpSO;
        private PowerUpPool powerUpPool;
        private bool isSpawning;
        private float spawnTimer;
        private BoxCollider powerUpSpawnArea;

        public PowerUpService(PowerUpSO powerUpSO, BoxCollider powerUpSpawnArea)
        {
            this.powerUpSO = powerUpSO;
            powerUpPool = new PowerUpPool();
            spawnTimer = this.powerUpSO.spawnRate;
            isSpawning = true;
            this.powerUpSpawnArea = powerUpSpawnArea;
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
                powerUp.Configure(GetSpawnPosition());
            }
        }

        private PowerUpController FetchPowerUp(PowerUpType typeToFetch)
        {
            PowerUpData fetchedData = powerUpSO.powerUpData.Find(item => item.powerUpType == typeToFetch);

            switch (typeToFetch)
            {
                case PowerUpType.SpeedBooster:
                    return (PowerUpController)powerUpPool.GetPowerUp<SpeedBooster>(fetchedData);
                case PowerUpType.Shield:
                    return (PowerUpController)powerUpPool.GetPowerUp<Shield>(fetchedData);
                case PowerUpType.Destroyer:
                    return (PowerUpController)powerUpPool.GetPowerUp<Destroyer>(fetchedData);
                default:
                    throw new Exception($"Failed to Create PowerUpController for: {typeToFetch}");
            }
        }

        public Vector3 GetSpawnPosition()
        {
            Vector3 center = powerUpSpawnArea.center + powerUpSpawnArea.transform.position;
            Vector3 size = powerUpSpawnArea.size;

            Vector3 randomLocal = new Vector3(
                UnityEngine.Random.Range(-size.x / 2, size.x / 2),
                UnityEngine.Random.Range(-size.y / 2, size.y / 2),
                UnityEngine.Random.Range(-size.z / 2, size.z / 2)
            );

            return center + powerUpSpawnArea.transform.rotation * randomLocal;
        }

        public void ReturnPowerUpToPool(PowerUpController powerUpToReturn)
            => powerUpPool.ReturnItem(powerUpToReturn);
    }
}
