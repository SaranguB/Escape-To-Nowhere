using StateMachine;
using UnityEngine;

namespace Player
{
    public abstract class PlayerBaseState : IState<PlayerController>
    {
        public PlayerController owner { get; set; }

        protected void HandleMovementInput()
        {
            owner.PlayerModel.turnInput = Input.GetAxis("Horizontal");
        }

        public abstract void OnStateEnter();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void OnStateExit();
    }
}