using UnityEngine;

namespace PowerUps
{
    public class SpeedBooster : PowerUpController
    {
        private PowerUpData dataToUse;

        public SpeedBooster(PowerUpData dataToUse) : base(dataToUse)
        {
            this.dataToUse = dataToUse;
        }

        public override void Activate()
        {
            base.Activate();
            Debug.Log("activated");
        }

        public override void Deactivate()
        {
            base.Deactivate();
            Debug.Log("Deactivated");

        }
    }
}
