using Main;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUIView : IUIView
    {
        [SerializeField] private GameObject title;
        [SerializeField] private UISO menuSO;
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;

        private void Awake()
        {
            AnimateTitleBounce(title);
        }

        private void Start()
        {
            AddlistenerToButton();
        }

        private void AddlistenerToButton()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            quitButton.onClick.AddListener(OnQuitButtonClicked);
        }

        private void OnQuitButtonClicked()
        {
            PlayButtonSound();
            Application.Quit();
        }

        public void PlayButtonSound()
         => GameService.Instance.soundService.PlaySoundEffects(Audio.SoundType.ButtonSound);

        private void OnPlayButtonClicked()
        {
            PlayButtonSound();
            int gameplayIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadSceneAsync(gameplayIndex);
        }

        public void OnHoverEnterPlayButton()
        {
            ScaleButton(playButton.gameObject, menuSO.originalScale * menuSO.scaleFactor, menuSO.animationTime);
        }

        public void OnHoverExitPlayButton()
        {
            ScaleButton(playButton.gameObject, menuSO.originalScale, menuSO.animationTime);
        }

        public void OnHoverEnterQuitButton()
        {
            ScaleButton(quitButton.gameObject, menuSO.originalScale * menuSO.scaleFactor, menuSO.animationTime);
        }

        public void OnHoverExitQuitButton()
        {
            ScaleButton(quitButton.gameObject, menuSO.originalScale, menuSO.animationTime);
        }

        void AnimateTitleBounce(GameObject title)
        {
            Vector3 originalPos = title.transform.localPosition;
            title.transform.localPosition += menuSO.screenOffsetPosition;
            LeanTween.moveLocal(title, originalPos, menuSO.titleAnimationDelay).setEaseOutBounce();
        }
    }
}
