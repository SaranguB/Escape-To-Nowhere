using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/enemy")]
    public class EnemySpawnSO : ScriptableObject
    {
        public float spawnOffset;
    }

    
}