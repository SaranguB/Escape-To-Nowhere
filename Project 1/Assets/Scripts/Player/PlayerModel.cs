using UnityEngine;

namespace Player
{
    public class PlayerModel
    {
        public PlayerSO playerSO;
        public float moveSpeed;
        public float turnInput;
        public float turnAmount;
        public bool isShieldActivated = false;
        public float highScore = 0;

        public PlayerModel(PlayerSO playerSO)
        {
            this.playerSO = playerSO;

            moveSpeed = playerSO.moveSpeed;
        }
    }
}
