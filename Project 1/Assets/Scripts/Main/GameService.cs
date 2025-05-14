using Enemy;
using Events;
using Player;
using PowerUps;
using System;
using UnityEngine;
using Utilities;

namespace Main
{
    public class GameService : GenericMonoSingelton<GameService>
    {
        #region Dependencies
        public PlayerService playerService;
        public EventService eventService;
        public EnemyService enemyService;
        public PowerUpService powerUpService;
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
        #endregion



        protected override void Awake()
        {
            base.Awake();
            eventService = new EventService();
            playerService = new PlayerService(playerView, playerSO);
            powerUpService = new PowerUpService(powerUpSO, entitySpawnArea);
            enemyService = new EnemyService(enemySO, entitySpawnArea);
        }


        private void Update()
        {
            enemyService?.Update();
            powerUpService?.Update();
        }
    }
}