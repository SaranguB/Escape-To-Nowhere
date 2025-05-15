using PowerUps;
using System;
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
            playerController.UpdateState();

            playerController.OnPlayerPositionChanged(playerRB.position);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider is not TerrainCollider && !other.gameObject.TryGetComponent<PowerUpView>(out _))
            {
                if (!playerController.IsShiedActivated())
                {
                    //Debug.Log("Failed by colllsion");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Boundary"))
            {
                //Debug.Log("Failed by boundary");
            }
        }

        private void FixedUpdate()
        {
            playerController.FixedUpdateState();
        }

        public Rigidbody GetPlayerRigidBody()
            => playerRB;

        public ParticleSystem GetShieldParticleEffect()
            => shieldParticleEffect;
    }
}
