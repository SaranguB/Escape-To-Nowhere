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
    }
}
