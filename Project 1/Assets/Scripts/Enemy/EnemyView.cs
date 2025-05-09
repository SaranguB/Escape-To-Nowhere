using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;

        [SerializeField] private Rigidbody enemyRB;
        public void SetController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void SetPosition(Vector3 spawnPosition)
        {
            this.transform.position = spawnPosition;
        }

        public Rigidbody GetEnemyRB()
            => enemyRB;
    }
}
