using System.Runtime;
using UnityEngine;
[System.Serializable]
public class FireRatePowerup: Powerups
{
    public float fireRateToAdd;
    public float fierRatetoRemove;
    public void start()
    {

    }
    public override void Apply(PowerupManager target)
    {
        //applies firerate changes
        //gets the pawn to get the firerate, then checks if it has a pawn, to make sure it has a firerate
        Pawn targetFireRate = target.GetComponent<Pawn>();
        if (targetFireRate != null!)
        {
            //gets the pawn to increase there fireRate
           targetFireRate.IncreaseFireRate(fireRateToAdd, target.GetComponent<Pawn>());
        }

    }
    public override void Remove(PowerupManager target)
    {
        Pawn targetFireRate = target.GetComponent<Pawn>();
        targetFireRate.IncreaseFireRate(fierRatetoRemove, target.GetComponent<Pawn>());
    }

}
