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
        #endregion

        #region Serilized Fields
        [Header("Player")]
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerSO playerSO;

        #endregion



        protected override void Awake()
        {
            base.Awake();
            eventService = new EventService();
            playerService = new PlayerService(playerView, playerSO);

        }
    }
}