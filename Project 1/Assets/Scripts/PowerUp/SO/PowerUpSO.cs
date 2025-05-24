using System;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(fileName = "PowerUps", menuName = "ScriptableObjects/PowerUps")]
    public class PowerUpSO : ScriptableObject
    {
        public float spawnRate;
        public List<PowerUpData> powerUpData;
    }

    [Serializable]
    public struct PowerUpData
    {
        public PowerUpType powerUpType;
        public PowerUpView powerUpPrefab;
        public float powerUpSpawnDuration;
        public float activeDuration;
    }
}
