using Main;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilis;

namespace UI
{
    public class LevelLostUIView : IUIView
    {
        public LevelLostUIController levelLostUIController;
        public CanvasGroup levelEndUICanvasGroup;
        [SerializeField] private UISO levelFailedSO;
        public Button replayButton;
        public Button mainMenuButton;
        public TextMeshProUGUI highScoreText;
        public TextMeshProUGUI survivedTimeText;

        public void SetController(LevelLostUIController levelLostUIController)
        {
            this.levelLostUIController = levelLostUIController;
        }

        private void Awake()
        {
            AddListenersToButton();
            CanvasGroupExtension.Hide(levelEndUICanvasGroup);
        }

        public void AddListenersToButton()
        {
            replayButton.onClick.AddListener(OnReplayButtonClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnMainMenuButtonClicked()
        {
            PlayButtonSound();
            levelLostUIController.ChangeStateToMainMenu();
            SceneManager.LoadScene("MainMenu");

        }

        private void OnReplayButtonClicked()
        {
            PlayButtonSound();
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadSceneAsync(currentScene.name);
        }

        public void PlayButtonSound()
           => GameService.Instance.soundService.PlaySoundEffects(Audio.SoundType.ButtonSound);

        private void OnDestroy()
        {
            replayButton.onClick.RemoveListener(OnReplayButtonClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        public void OnHoverEnterReplayButton()
        {
            ScaleButton(replayButton.gameObject, levelFailedSO.originalScale * levelFailedSO.scaleFactor, levelFailedSO.animationTime);
        }

        public void OnHoverExitReplayButton()
        {
            ScaleButton(replayButton.gameObject, levelFailedSO.originalScale, levelFailedSO.animationTime);
        }

        public void OnHoverEnterMenuButton()
        {
            ScaleButton(mainMenuButton.gameObject, levelFailedSO.originalScale * levelFailedSO.scaleFactor, levelFailedSO.animationTime);
        }

        public void OnHoverExitMenuButton()
        {
            ScaleButton(mainMenuButton.gameObject, levelFailedSO.originalScale, levelFailedSO.animationTime);
        }

        public void SetHighScore()
        {
            float highscore = PlayerPrefs.GetFloat("HighScore", 0f);
            SetTimerText(highscore, highScoreText);
        }

        public void SetCurrentScore(float currentScore)
        {
            SetTimerText(currentScore, survivedTimeText);
        }
    }
}


