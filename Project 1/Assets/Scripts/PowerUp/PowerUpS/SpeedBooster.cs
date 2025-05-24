using Main;

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
            GameService.Instance.eventService.onSpeedBoosterToggled.InvokeEvent(true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            GameService.Instance.eventService.onSpeedBoosterToggled.InvokeEvent(false);
        }
    }
}
