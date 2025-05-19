using System;
using UnityEngine;

namespace UI
{
    public class UIService : MonoBehaviour
    {
        [Header("Timer UI")]
        private TimerUIController timerUIController;
        [SerializeField] private TimerUIView timerUIView;

        [Header("Main Menu UI")]
        private MainMenuUIController mainMenuUIController;
        [SerializeField] private MainMenuUIView mainMenuUIView;

        private void Start()
        {
            InitializeUIControllers();
        }

        private void InitializeUIControllers()
        {
            if (timerUIView != null)
                timerUIController = new TimerUIController(timerUIView);

            if(mainMenuUIView!=null)
                mainMenuUIController = new MainMenuUIController(mainMenuUIView);
        }

        public void UpdateTimer(float elapsedTime)
        {
            timerUIController.UpdateTimer(elapsedTime);
        }
    }
}
