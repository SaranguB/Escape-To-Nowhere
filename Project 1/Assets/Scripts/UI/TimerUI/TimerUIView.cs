using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerUIView : IUIView
    {
        [SerializeField] private TextMeshProUGUI timerText;

        public void UpdateTimer(float elapsedTime)
        {
            SetTimerText(elapsedTime, timerText);
        }
    }
}
