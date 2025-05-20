using Main;
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

        [Header("Level Failed UI")]
        private LevelLostUIController levelLostUIController;
        [SerializeField] LevelLostUIView levelLostUIView;


        private void Start()
        {
            InitializeUIControllers();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.eventService.OnPlayerDead.AddListener(CreateLevelLostUI);
        }

        private void InitializeUIControllers()
        {
            if (timerUIView != null)
                timerUIController = new TimerUIController(timerUIView);

            if (mainMenuUIView != null)
                mainMenuUIController = new MainMenuUIController(mainMenuUIView);
        }

        public void CreateLevelLostUI(float currentScore)
        {
            if (levelLostUIView != null)
                levelLostUIController = new LevelLostUIController(levelLostUIView, currentScore);
        }

        public void UpdateTimer(float elapsedTime)
        {
            timerUIController.UpdateTimer(elapsedTime);
        }
    }
}
