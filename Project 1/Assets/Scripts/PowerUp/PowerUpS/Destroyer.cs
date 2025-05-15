using Main;
using UnityEngine;

namespace PowerUps
{
    public class Destroyer : PowerUpController
    {
        private PowerUpData dataToUse;

        public Destroyer(PowerUpData dataToUse) : base(dataToUse)
        {
            this.dataToUse = dataToUse;
        }

        public override void Activate()
        {
            base.Activate();
            GameService.Instance.eventService.OnDestroyerToggled.InvokeEvent();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }
    }
}
