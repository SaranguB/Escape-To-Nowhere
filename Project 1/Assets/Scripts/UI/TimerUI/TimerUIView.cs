using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        public void UpdateTimer(float elapsedTime)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
