using System;
using UnityEngine;
using UnityEngine.XR;

namespace Player
{
    public class PlayerController
    {
        private PlayerStateMachine playerStateMachine;

        private PlayerView playerView;
        public PlayerView PlayerView => playerView;

        private PlayerModel playerModel;
        public PlayerModel PlayerModel => playerModel;

        public PlayerController(PlayerView playerView, PlayerSO playerSO)
        {
            this.playerView = playerView;
            playerModel = new PlayerModel(playerSO);

            this.playerView.SetController(this);

            CreateStateMachine();
            ChangeState(PlayerState.Idle);
        }

        public void ChangeState(PlayerState playerState)
        {
            playerStateMachine.ChangeState(playerState);
        }

        private void CreateStateMachine()
        {
            playerStateMachine = new PlayerStateMachine(this, playerView.GetPlayerRigidBody());
        }

        public void FixedUpdateState()
        {
            playerStateMachine.FixedUpdate();
        }

        public void UpdateState()
        {
            playerStateMachine.Update();
        }

        public PlayerSO GetPlayerSO()
            => playerModel.playerSO;
    }
}
