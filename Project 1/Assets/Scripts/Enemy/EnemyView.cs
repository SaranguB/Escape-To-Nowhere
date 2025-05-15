using Main;
using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using VFX;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;

        [SerializeField] private Rigidbody enemyRB;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Transform enemyDestroyedVfXPosition;
        public void SetController(EnemyController enemyController)
        {
            this.enemyController = enemyController;
        }

        public void SetPosition(Vector3 spawnPosition)
        {
            this.transform.position = spawnPosition;
        }

        private void Start()
        {
            enemyController.ChangeState(EnemyStates.Attack);
        }

        public Rigidbody GetEnemyRB()
            => enemyRB;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider is not TerrainCollider)
            {
                DestroyEnemy();
            }
        }

        public void DestroyEnemy()
        {
            enemyController.DestroyEnemy(VFXType.EnemyDeathEffect, enemyDestroyedVfXPosition.position);
        }

        public NavMeshAgent GetNavMeshAgent()
            => navMeshAgent;

        private void Update()
        {
            enemyController.UpdateStateMachine();
        }
    }
}
