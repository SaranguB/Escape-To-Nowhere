using System;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController PlayerController;

        [SerializeField] private Rigidbody playerRB;

        public void SetController(PlayerController playerController)
        {
            this.PlayerController = playerController;
        }

        private void Start()
        {
            PlayerController.ChangeState(PlayerState.Move);
        }

        private void Update()
        {
            PlayerController.UpdateState();
        }

        private void FixedUpdate()
        {
            PlayerController.FixedUpdateState();
        }

        public Rigidbody GetPlayerRigidBody()
            => playerRB;
    }
}
