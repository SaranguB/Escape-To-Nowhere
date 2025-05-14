using UnityEngine;

namespace PowerUps
{
    public class SpeedBooster : PowerUpController
    {
        private PowerUpData dataToUse;

        public SpeedBooster(PowerUpData dataToUse)
        {
            this.dataToUse = dataToUse;
        }
    }
}
