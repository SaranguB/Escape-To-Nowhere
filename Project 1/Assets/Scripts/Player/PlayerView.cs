using Main;
using PowerUps;
using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        private PlayerController playerController;

        [SerializeField] private Rigidbody playerRB;

        [SerializeField] private ParticleSystem shieldParticleEffect;


        private void OnDestroy()
        {
            playerController.UnSubscribeToEvents();
        }

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        private void Start()
        {
            playerController.ChangeState(PlayerState.Move);
        }

        private void Update()
        {
            if (playerController.GetCurrentGameState() == GameState.Gameplay)
            {
                playerController.UpdateState();

                playerController.OnPlayerPositionChanged(playerRB.position);
            }

        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider is not TerrainCollider && !other.gameObject.TryGetComponent<PowerUpView>(out _))
            {
                if (!playerController.IsShiedActivated())
                {
                    StartCoroutine(OnPlayerDead());
                }
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Boundary"))
            {
                OnPlayerDead();
            }
        }

        private IEnumerator OnPlayerDead()
        {
            playerController.SetPlayerDeathValues(transform.position);

            yield return new WaitForSeconds(2f);
            playerController.OnPlayerDead();
        }


        private void FixedUpdate()
        {
            if (playerController.GetCurrentGameState() == GameState.Gameplay)
            {
                playerController.FixedUpdateState();
            }
        }

        public Rigidbody GetPlayerRigidBody()
            => playerRB;

        public ParticleSystem GetShieldParticleEffect()
            => shieldParticleEffect;
    }
}
