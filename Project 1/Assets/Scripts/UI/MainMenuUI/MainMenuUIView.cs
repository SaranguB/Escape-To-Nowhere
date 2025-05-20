using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUIView : MonoBehaviour
    {
        [SerializeField] private GameObject title;
        [SerializeField] private MainMenuSO menuSO;
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
            Application.Quit();
        }

        private void OnPlayButtonClicked()
        {
            int gameplayIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadSceneAsync(gameplayIndex);
        }

        public void OnHoverEnterPlayButton()
        {
            LeanTween.scale(playButton.gameObject, menuSO.originalScale * menuSO.scaleFactor, menuSO.animationTime).setEaseInOutBack();
        }

        public void OnHoverExitPlayButton()
        {
            LeanTween.scale(playButton.gameObject, menuSO.originalScale, menuSO.animationTime).setEaseInOutBack();
        }

        public void OnHoverEnterQuitButton()
        {
            LeanTween.scale(quitButton.gameObject, menuSO.originalScale * menuSO.scaleFactor, menuSO.animationTime).setEaseInOutBack();
        }

        public void OnHoverExitQuitButton()
        {
            LeanTween.scale(quitButton.gameObject, menuSO.originalScale, menuSO.animationTime).setEaseInOutBack();
        }

        public void SetController()
        {

        }

        void AnimateTitleBounce(GameObject title)
        {
            Vector3 originalPos = title.transform.localPosition;
            title.transform.localPosition += menuSO.screenOffsetPosition;
            LeanTween.moveLocal(title, originalPos, menuSO.titleAnimationDelay).setEaseOutBounce();
        }
    }
}
