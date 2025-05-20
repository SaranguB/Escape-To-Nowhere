using Main;
using System;
using UnityEngine;

namespace Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        public PlayerService(PlayerView playerView, PlayerSO playerSO)
        {
            playerController = new PlayerController(playerView, playerSO);
        }

        public void Start()
        {
            GameService.Instance.ChangeGameState(GameState.Gameplay);
        }
    }
}
