using System;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;

        [SerializeField] private Rigidbody playerRB;

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        private void Start()
        {
            playerController.ChangeState(PlayerState.Move);
        }

        private void Update()
        {
            playerController.UpdateState();

            playerController.OnPlayerPositionChanged(playerRB.position);
        }

        private void OnCollisionEnter(Collision other)
        {
            /*if (other.gameObject.CompareTag("tree"))
                Debug.Log("colliding");*/

        }

        private void FixedUpdate()
        {
            playerController.FixedUpdateState();
        }

        public Rigidbody GetPlayerRigidBody()
            => playerRB;
    }
}
