using Main;
using Player;
using System.Threading.Tasks;
using UnityEngine;


namespace PowerUps
{
    public class PowerUpController : IPowerUp
    {
        private PowerUpView powerUpView;
        private PowerUpData powerUpData;
        private bool isActive;

        public PowerUpController(PowerUpData powerUpData)
        {
            powerUpView = Object.Instantiate(powerUpData.powerUpPrefab);
            powerUpView.SetController(this);
            this.powerUpData = powerUpData;
        }

        private void StartPowerUpTimer()
        {
            powerUpView.StartPowerUpTimer(powerUpData.powerUpSpawnDuration);
        }

        public void Configure(Vector3 spawnPosition)
        {
            isActive = false;
            powerUpView.transform.position = spawnPosition;
            powerUpView.gameObject.SetActive(true);
            StartPowerUpTimer();
        }

        public void PowerUpTriggerEntered(GameObject collidedObject)
        {
            if (collidedObject.GetComponent<PlayerView>() != null)
            {
                Activate();
            }
        }

        public virtual void Activate()
        {
            isActive = true;
            StartActivationTimer();
            DisablePowerUp();
        }

        public void StartActivationTimer()
        {
            if (isActive)
            {
                powerUpView.StartTimer(powerUpData.activeDuration);
            }
        }

        public virtual void Deactivate()
        {
            isActive = false;
            GameService.Instance.powerUpService.ReturnPowerUpToPool(this);
        }

        public void DisablePowerUp()
        {
            powerUpView.gameObject.SetActive(false);
        }

        public void DestroyPowerUp()
        {
            DisablePowerUp();
            Deactivate();
        }
    }
}
