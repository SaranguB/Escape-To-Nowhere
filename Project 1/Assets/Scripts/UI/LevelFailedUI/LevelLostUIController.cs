using Main;
using Utilis;

namespace UI
{
    public class LevelLostUIController
    {
        private LevelLostUIView levelLostUIView;

        public LevelLostUIController(LevelLostUIView levelLostUIView, float currentScore)
        {
            this.levelLostUIView = levelLostUIView;
            this.levelLostUIView.SetController(this);

            EnableLevelLostUI(currentScore);
        }

        public void EnableLevelLostUI(float currentScore)
        {
            CanvasGroupExtension.Show(levelLostUIView.levelEndUICanvasGroup);
            levelLostUIView.SetHighScore();
            levelLostUIView.SetCurrentScore(currentScore);
        }

        public void ChangeStateToMainMenu()
        {
           GameService.Instance.ChangeGameState(GameState.MainMenu);
        }
    }
}
