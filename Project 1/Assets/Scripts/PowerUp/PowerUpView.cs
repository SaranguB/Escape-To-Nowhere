using System;
using System.Collections;
using UnityEngine;

namespace PowerUps
{
    public class PowerUpView : MonoBehaviour
    {
        private PowerUpController powerUpController;

        public void  SetController(PowerUpController powerUpController)
        {
           this.powerUpController = powerUpController;
        }

        public void StartTimer(float activeDuration)
        {
            StartCoroutine(Deactivate(activeDuration));
        }

        public void StartPowerUpTimer(float powerUpSpawnDuration)
        {
            StartCoroutine(DisablePowerUp(powerUpSpawnDuration));
        }

        private IEnumerator DisablePowerUp(float powerUpSpawnDuration)
        {
            yield return new WaitForSeconds(powerUpSpawnDuration);
            powerUpController.DestroyPowerUp();
        }

        private IEnumerator Deactivate(float activeDuration)
        {
            yield return new WaitForSeconds(activeDuration);
            powerUpController.Deactivate();
        }

        private void OnCollisionEnter(Collision other)
        {
            powerUpController?.PowerUpTriggerEntered(other.gameObject);
        }

    }
}
