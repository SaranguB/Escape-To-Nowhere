namespace UI
{
    public class TimerUIController
    {
        private TimerUIView timerUIView;
        public TimerUIController(TimerUIView timerUIView)
        {
            this.timerUIView = timerUIView;
        }

        public void UpdateTimer(float elapsedTime)
        {
            timerUIView.UpdateTimer(elapsedTime);
        }
    }
}
