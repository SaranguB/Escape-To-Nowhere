using Main;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;

        [SerializeField] private Rigidbody enemyRB;
        [SerializeField] private NavMeshAgent navMeshAgent;

        public TreeCollisonManager collisionManager;

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
                enemyController.DestroyEnemy();
            }
        }



        public NavMeshAgent GetNavMeshAgent()
            => navMeshAgent;

        private void Update()
        {
            enemyController.UpdateStateMachine();
        }
    }
}
