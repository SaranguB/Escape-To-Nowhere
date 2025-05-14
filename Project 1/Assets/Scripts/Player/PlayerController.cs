using Main;
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

        private PlayerSO playerSO;
        public PlayerController(PlayerView playerView, PlayerSO playerSO)
        {
            this.playerView = playerView;
            playerModel = new PlayerModel(playerSO);
            this.playerSO = playerSO;
            this.playerView.SetController(this);

            CreateStateMachine();
            ChangeState(PlayerState.Idle);

            SubscribeToEvents();
            UnSubscribeToEvents();
        }

        private void UnSubscribeToEvents()
        {
            throw new NotImplementedException();
        }

        private void SubscribeToEvents()
        {
            throw new NotImplementedException();
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

        public void OnPlayerPositionChanged(Vector3 position)
        {
            GameService.Instance.eventService.onPlayerPositionChanged.InvokeEvent(position);
        }

        public void ToggleBoosterSpeed(bool boosterSpeedActive)
            => playerModel.moveSpeed = boosterSpeedActive ? playerSO.boosterSpeed : playerSO.moveSpeed;
    }
}
