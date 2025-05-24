using Audio;
using Enemy;
using Events;
using Player;
using PowerUps;
using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;
using VFX;

namespace Main
{
    public class GameService : GenericMonoSingelton<GameService>
    {
        #region Dependencies
        public PlayerService playerService;
        public EventService eventService;
        public EnemyService enemyService;
        public PowerUpService powerUpService;
        public UIService uiService;
        public VFXService vfxService;
        public SoundService soundService;
        #endregion

        #region Serilized Fields
        [Header("Player")]
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerSO playerSO;
        [SerializeField] private BoxCollider entitySpawnArea;

        [Header("Enemy")]
        [SerializeField] private EnemySO enemySO;

        [Header("PowerUp")]
        [SerializeField] private PowerUpSO powerUpSO;

        [Header("VFX")]
        [SerializeField] VFXView vfxView;

        [Header("Sound")]
        [SerializeField] private SoundSO soundSO;
        [SerializeField] private AudioSource audioEffectSource;
        [SerializeField] private AudioSource backgroundMusicSource;
        #endregion

        public GameState gameState { get; private set; }

        private float elapsedTime;

        protected override void Awake()
        {
            base.Awake();
            eventService = new EventService();
            soundService = new SoundService(soundSO, audioEffectSource, backgroundMusicSource);

            if (vfxView != null)
                vfxService = new VFXService(vfxView);

            if (playerView != null)
                playerService = new PlayerService(playerView, playerSO);

            if (powerUpSO != null)
                powerUpService = new PowerUpService(powerUpSO, entitySpawnArea);

            if (enemySO != null)
                enemyService = new EnemyService(enemySO, entitySpawnArea);
        }

        private void Start()
        {
            playerService?.Start();
            PlayBackgroundMusic();
        }

        private void Update()
        {
            if (gameState == GameState.Gameplay)
            {
                enemyService?.Update();
                powerUpService?.Update();

                UpdateTimer();
            }
        }

        private void OnDestroy()
        {
            enemyService?.UnSubscribeToEvents();
        }

        private void UpdateTimer()
        {

            elapsedTime += Time.deltaTime;
            uiService.UpdateTimer(elapsedTime);
        }

        public void ChangeGameState(GameState newState)
          => gameState = newState;


        private void PlayBackgroundMusic()
        {
            if (SceneManager.GetActiveScene().name == "MainMenu")
                soundService.PlayBackgroundMusic(SoundType.MenuBackground);
            else
                soundService.PlayBackgroundMusic(SoundType.GameplayBackground);
        }

        public float GetElapsedTime()
            => elapsedTime;

        public GameState GetCurrentGameState()
            => gameState;
    }
}