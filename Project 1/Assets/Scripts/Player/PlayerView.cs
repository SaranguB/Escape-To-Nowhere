using System;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController PlayerController;

        public void SetController(PlayerController playerController)
        {
            this.PlayerController = playerController;
        }

        private void FixedUpdate()
        {
        }
    }
}
