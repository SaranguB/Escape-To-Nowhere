using Main;
using System;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyController
    {
        private EnemyData dataToUse;
        private Vector3 playerPosition;

        public EnemyController(EnemyData enemyData)
        {
            this.dataToUse = enemyData;
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            GameService.Instance.eventService.onPlayerPositionChanged.AddListener(SetPlayerPosition);
        }

        public void UnSubscribeToEvents()
        {
            GameService.Instance.eventService.onPlayerPositionChanged.RemoveListener(SetPlayerPosition);
        }

        public virtual void ConfigureEnemy(Vector3 spawnPosition)
        {
        }

        public void SetPlayerPosition(Vector3 playerPosition)
            => this.playerPosition = playerPosition;

        public Vector3 GetPlayerPosition()
            => playerPosition;

        public virtual void DestroyEnemy(VFX.VFXType enemyDeathEffect, Vector3 position)
        {
            PlayEnemyExplosionAtPosition(enemyDeathEffect, position);
        }

        public void PlayEnemyExplosionAtPosition(VFX.VFXType enemyDeathEffect, Vector3 position)
        {
            if (GetGameState() == GameState.Gameplay)
                GameService.Instance.soundService.PlaySoundEffects(Audio.SoundType.DeathSound);

            GameService.Instance.vfxService.PlayVFXAtPosition(enemyDeathEffect, position);
        }

        public abstract void RemoveEnemy();
        public abstract void UpdateStateMachine();
        public abstract void ChangeState(EnemyStates attack);

        public GameState GetGameState()
        {
            return GameService.Instance.gameState;
        }
    }
}
