using System;
using UnityEngine;

namespace UI
{
    public class UIService : MonoBehaviour
    {
        [Header("Timer UI View")]
        private TimerUIController timerUIController;
        [SerializeField] private TimerUIView timerUIView;

        private void Start()
        {
            InitializeUIControllers();
        }

        private void InitializeUIControllers()
        {
            timerUIController = new TimerUIController(timerUIView);
        }

        public void UpdateTimer(float elapsedTime)
        {
            timerUIController.UpdateTimer(elapsedTime);
        }
    }
}
