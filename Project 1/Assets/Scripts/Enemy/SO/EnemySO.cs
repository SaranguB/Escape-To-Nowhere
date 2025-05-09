using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/enemy")]
    public class EnemySO : ScriptableObject
    {
        public float spawnRate;
        public float spawnOffset;
        public float rayOrigionYValue;
        public List<EnemyData> enemyData;
    }

    [Serializable]
    public struct EnemyData
    {
        public EnemyView enemyPrefab;
        public EnemyType enemyType;
        public float speed;
        public int groundCheckDistance;
    }
}