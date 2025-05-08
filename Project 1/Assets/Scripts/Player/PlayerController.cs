using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;

        public PlayerController(PlayerView playerView, PlayerSO playerSO)
        {
            this.playerView = playerView;
            playerModel = new PlayerModel(playerSO);

            this.playerView.SetController(this);
        }
    }
}
