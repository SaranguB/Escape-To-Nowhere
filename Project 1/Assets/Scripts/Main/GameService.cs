using Enemy;
using Events;
using Player;
using PowerUps;
using System;
using UI;
using UnityEngine;
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
        #endregion

        public GameState gameState { get; private set; }

        private float elapsedTime;

        protected override void Awake()
        {
            base.Awake();
            eventService = new EventService();
            vfxService = new VFXService(vfxView);
            playerService = new PlayerService(playerView, playerSO);
            powerUpService = new PowerUpService(powerUpSO, entitySpawnArea);
            enemyService = new EnemyService(enemySO, entitySpawnArea);
        }

        private void Start()
        {
            ChangeGameState(GameState.Gameplay);
        }

        private void Update()
        {
            enemyService?.Update();
            powerUpService?.Update();

            UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (gameState == GameState.Gameplay)
            {
                elapsedTime += Time.deltaTime;
                uiService.UpdateTimer(elapsedTime);
            }
        }

        public void ChangeGameState(GameState newState)
        {
            gameState = newState;
        }
    }
}