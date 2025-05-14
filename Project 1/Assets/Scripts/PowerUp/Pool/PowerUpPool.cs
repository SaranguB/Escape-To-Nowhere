using System;
using ObjectPool;
using PowerUps;

public class PowerUpPool : GenericObjectPool<IPowerUp>
{
    private PowerUpData dataToUse;

    public IPowerUp GetPowerUp<T>(PowerUpData powerUpData) where T : IPowerUp
    {
        dataToUse = powerUpData;
        return GetItem<T>();
    }

    protected override IPowerUp CreateItem<T>()
    {
        if (typeof(T) == typeof(SpeedBooster))
            return new SpeedBooster(dataToUse);
        else
            throw new NotSupportedException($"Power-up type '{typeof(T)}' is not supported.");
    }

}
