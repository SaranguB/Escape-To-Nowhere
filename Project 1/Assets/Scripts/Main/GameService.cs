using Enemy;
using Events;
using Player;
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
        #endregion

        #region Serilized Fields
        [Header("Player")]
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerSO playerSO;

        [Header("Enemy")]
        [SerializeField] private EnemySO enemySO;
        [SerializeField] private BoxCollider enemySpawnArea;
        #endregion



        protected override void Awake()
        {
            base.Awake();
            eventService = new EventService();
            playerService = new PlayerService(playerView, playerSO);
            enemyService = new EnemyService(enemySO, enemySpawnArea);

        }

        private void Update()
        {
            enemyService?.Update();
        }
    }
}