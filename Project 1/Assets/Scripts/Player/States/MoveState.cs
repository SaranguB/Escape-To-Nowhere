using StateMachine;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

namespace Player
{
    public class MoveState : PlayerBaseState
    {
        private Rigidbody playerRB;

        public MoveState(Rigidbody playerRB)
        {
            this.playerRB = playerRB;
        }

        public override void OnStateEnter()
        {
        }

        public override void UpdateState()
        {
            HandleMovementInput();
        }

        public override void FixedUpdateState()
        {
            Move();
            HandleRotation();
            ForceStayToTheGround();
        }

        private void ForceStayToTheGround()
        {
            RaycastHit hit;
            float groundCheckDistance = owner.PlayerModel.playerSO.groundCheckDistance;
            if (Physics.Raycast(playerRB.position, Vector3.down, out hit, groundCheckDistance))
            {
                Vector3 targetPosition = new Vector3(playerRB.position.x, hit.point.y, playerRB.position.z);
                playerRB.MovePosition(targetPosition);
            }
        }

        private void HandleRotation()
        {
            owner.PlayerModel.turnAmount = owner.PlayerModel.turnInput *
                            owner.PlayerModel.playerSO.turnSpeed * Time.fixedDeltaTime;

            Quaternion turnOffset = Quaternion.Euler(0, owner.PlayerModel.turnAmount, 0);
            playerRB.MoveRotation(playerRB.rotation * turnOffset);
        }

        private void Move()
        {
            playerRB.linearVelocity = playerRB.transform.forward * owner.PlayerModel.moveSpeed;
        }

        public override void OnStateExit()
        {
        }
    }
}