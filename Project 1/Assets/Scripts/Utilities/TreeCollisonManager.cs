using Enemy;
using System;
using UnityEngine;

public class TreeCollisonManager : MonoBehaviour
{
    private EnemyController enemyController;

    public void SetController(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yes");

        if (other.gameObject.CompareTag("tree"))
        {
            enemyController.DestroyEnemy();
            Debug.Log("colliding");
        }
    }
}
