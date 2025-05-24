using Main;

namespace PowerUps
{
    public class Shield : PowerUpController
    {
        private PowerUpData dataToUse;

        public Shield(PowerUpData dataToUse) : base(dataToUse)
        {
            this.dataToUse = dataToUse;
        }

        public override void Activate()
        {
            base.Activate();
            GameService.Instance.eventService.OnShieldToggled.InvokeEvent(true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            GameService.Instance.eventService.OnShieldToggled.InvokeEvent(false);
        }
    }
}
